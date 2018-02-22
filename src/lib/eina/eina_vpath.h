#ifndef EINA_VPATH_H
#define EINA_VPATH_H

#include "eina_prefix.h"

/*
 * Eina_vpath
 * eina vpath is a path that can be prefixed with a virtual path.
 *
 * A virutla path can either start with (:XXXXXXXX:) that indicates a virtual path, OR normal with / or ./ or ../ or ~
 * The char sequence in between (: and :) are used as key to lookup the real value.
 * The key has to be set by a interface before, otherwise you will get a error.
 *
 * The symbol ~ is interpretated as the home directory of the running user, and will be replaced.
 * Additional infos: https://phab.enlightenment.org/w/eina_vpath/
 */

/**
 * This datatype is a vpath, this means you can use the syntax described above.
 */
typedef const char* Eina_Vpath;


typedef struct
{
  const char *desktop;
  const char *documents;
  const char *downloads;
  const char *music;
  const char *pictures;
  const char *pub;
  const char *templates;
  const char *videos;
  const char *data;
  const char *config;
  const char *cache;
  const char *run;
} Eina_Vpath_Interface_User;

/**
 * Make the app specific paths accessable as virtual path
 *
 * This will create :
 *   - app.dir
 *   - app.bin
 *   - app.lib
 *   - app.data
 *   - app.locale
 *   - app.config
 *   - app.cache
 *   - app.local
 *
 * If you do NOT call this api the virtual paths for app.* will be unset
 */
EAPI void eina_vpath_interface_app_set(const char *app_name, Eina_Prefix *p);

/**
 * Create the desktop specific vpaths
 *
 * The virtual paths will be named usr.<field-name-of-struct>
 *
 * If you do NOT call this api the virtual paths for usr.* will be unset.
 */
EAPI void eina_vpath_interface_user_set(Eina_Vpath_Interface_User *user);

/*
 * Translate a virtual path into a normal path.
 *
 * @return a string that is not virtual anymore
 *
 */
EAPI char* eina_vpath_resolve(Eina_Vpath path);

#endif