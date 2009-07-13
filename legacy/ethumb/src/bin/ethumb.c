/**
 * @file
 *
 * Copyright (C) 2009 by ProFUSION embedded systems
 *
 * This program is free software; you can redistribute it and/or modify it
 * under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or (at your
 * option) any later version.
 *
 * This program is distributed in the hope that it will be useful,  but
 * WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
 * or FITNESS FOR A PARTICULAR PURPOSE.  See the  GNU General Public License
 * for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with this program; if not, write to the Free Software Foundation,
 * Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301,
 * USA.
 *
 * @author Rafael Antognolli <antognolli@profusion.mobi>
 */
#include <config.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <limits.h>
#include <Ethumb.h>
#include <Eina.h>
#include <Ecore_Getopt.h>
#include <Ecore.h>

const char *aspect_opt[] = { "keep", "ignore", "crop", NULL };
const char *format_opt[] = { "png", "jpg", "eet", NULL };
struct frame
{
   const char *file;
   const char *group;
   const char *swallow;
};

static unsigned char
_ethumb_getopt_callback_frame_parse(const Ecore_Getopt *parser, const Ecore_Getopt_Desc *desc, const char *str, void *data, Ecore_Getopt_Value *storage)
{
   struct frame *f = (struct frame *)storage->ptrp;
   const char *tfile, *tgroup, *tswallow;
   char *text;
   char *sep;

   tfile = NULL;
   tgroup = NULL;
   tswallow = NULL;

   text = strdup(str);

   sep = strchr(text, ':');
   if (!sep)
     {
	fprintf(stderr, "ERROR: invalid theme: '%s'\n", text);
	goto error;
     }
   *sep = '\0';
   tfile = eina_stringshare_add(text);

   sep++;
   text = sep;
   sep = strchr(text, ':');
   if (!sep)
     {
	fprintf(stderr, "ERROR: invalid theme: '%s'\n", text);
	goto error;
     }
   *sep = '\0';
   tgroup = eina_stringshare_add(text);

   sep++;
   tswallow = eina_stringshare_add(sep);

   f->file = tfile;
   f->group = tgroup;
   f->swallow = tswallow;

   return 1;

 error:
   eina_stringshare_del(tfile);

   return 0;
}

const Ecore_Getopt optdesc = {
  "ethumb",
  NULL,
  PACKAGE_VERSION,
  "(C) 2009 - ProFUSION embedded systems",
  "LGPL v3 - GNU Lesser General Public License",
  "Thumbnails generator.\n"
     "\n"
     "This program uses ethumb to create thumbnails from pictures. "
     "It's an example of use and a test for ethumb.\n",
  0,
  {
     ECORE_GETOPT_CALLBACK_ARGS
     ('s', "size", "thumbnail size expected.",
      "WxH", ecore_getopt_callback_size_parse, NULL),
     ECORE_GETOPT_CHOICE
     ('f', "format", "file format to save.", format_opt),
     ECORE_GETOPT_CHOICE
     ('a', "aspect", "original image aspect ratio.", aspect_opt),
     ECORE_GETOPT_STORE_STR
     ('d', "directory", "directory to save thumbnails."),
     ECORE_GETOPT_STORE_STR
     ('c', "category", "thumbnails category."),
     ECORE_GETOPT_CALLBACK_ARGS
     ('t', "theme", "path to theme file, group and swallow part.",
      "file:group:swallow_part", _ethumb_getopt_callback_frame_parse, NULL),
     ECORE_GETOPT_STORE_STR
     ('k', "key", "key inside eet file to read image from."),
     ECORE_GETOPT_STORE_DOUBLE
     ('v', "video_time", "time of video frame to use as thumbnail."),
     ECORE_GETOPT_STORE_INT
     ('p', "document_page", "document page to use as thumbnail."),
     ECORE_GETOPT_LICENSE('L', "license"),
     ECORE_GETOPT_COPYRIGHT('C', "copyright"),
     ECORE_GETOPT_VERSION('V', "version"),
     ECORE_GETOPT_HELP('h', "help"),
     ECORE_GETOPT_SENTINEL
  }
};

static void
_finished_thumb(Ethumb *e, Eina_Bool success, void *data)
{
   ecore_main_loop_quit();
}

int
main(int argc, char *argv[])
{
   Ethumb *e;
   Eina_Bool quit_option = 0;
   Eina_Rectangle geometry = {-1, -1, -1, -1};
   unsigned int format = 0, aspect = 0;
   char *format_str = NULL;
   char *aspect_str = NULL;
   char *directory = NULL;
   char *category = NULL;
   char *src_key = NULL;
   struct frame frame = {NULL};
   const char *thumb_path = NULL;
   const char *thumb_key = NULL;
   double video_time = 0;
   int page = 0;
   int arg_index;
   int i;

   int r = 1;
   ethumb_init();
   ecore_init();

   Ecore_Getopt_Value values[] = {
	ECORE_GETOPT_VALUE_PTR_CAST(geometry),
	ECORE_GETOPT_VALUE_PTR_CAST(format_str),
	ECORE_GETOPT_VALUE_PTR_CAST(aspect_str),
	ECORE_GETOPT_VALUE_STR(directory),
	ECORE_GETOPT_VALUE_STR(category),
	ECORE_GETOPT_VALUE_PTR_CAST(frame),
	ECORE_GETOPT_VALUE_STR(src_key),
	ECORE_GETOPT_VALUE_DOUBLE(video_time),
	ECORE_GETOPT_VALUE_INT(page),
	ECORE_GETOPT_VALUE_BOOL(quit_option),
	ECORE_GETOPT_VALUE_BOOL(quit_option),
	ECORE_GETOPT_VALUE_BOOL(quit_option),
	ECORE_GETOPT_VALUE_BOOL(quit_option),
	ECORE_GETOPT_VALUE_NONE
   };

   arg_index = ecore_getopt_parse(&optdesc, values, argc, argv);
   if (arg_index < 0)
     {
	fprintf(stderr, "Could not parse arguments.\n");
	r = 0;
     }

   for (i = 0; i < 3; i++)
     if (format_opt[i] == format_str)
       {
	  format = i;
	  break;
       }

   for (i = 0; i < 3; i++)
     if (aspect_opt[i] == aspect_str)
       {
	  aspect = i;
	  break;
       }

   e = ethumb_new();

   ethumb_thumb_format_set(e, format);
   ethumb_thumb_aspect_set(e, aspect);
   if (directory) ethumb_thumb_dir_path_set(e, directory);
   if (category) ethumb_thumb_category_set(e, category);
   if (geometry.w > 0 && geometry.h > 0)
     ethumb_thumb_size_set(e, geometry.w, geometry.h);
   if (frame.file)
     {
	ethumb_frame_set(e, frame.file, frame.group, frame.swallow);
	eina_stringshare_del(frame.file);
	eina_stringshare_del(frame.group);
	eina_stringshare_del(frame.swallow);
     }
   if (video_time > 0)
     ethumb_video_time_set(e, video_time);
   if (page > 0)
     ethumb_document_page_set(e, page);

   if (r && arg_index < argc)
     r = ethumb_file_set(e, argv[arg_index++], src_key);
   else
     r = 0;
   if (r && arg_index < argc)
     thumb_path = argv[arg_index++];
   if (r && arg_index < argc)
     thumb_key = argv[arg_index];

   if (r)
     {
	ethumb_thumb_path_set(e, thumb_path, thumb_key);
	if (ethumb_exists(e))
	  {
	     quit_option = 1;
	     r = 1;
	  }
	else
	  r = ethumb_generate(e, _finished_thumb, NULL, NULL);
     }

   if (r && !quit_option)
     ecore_main_loop_begin();

   ethumb_file_free(e);
   ethumb_free(e);

   ecore_shutdown();
   ethumb_shutdown();

   return !r;
}
