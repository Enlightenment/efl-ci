#include <Elementary.h>
#include "elm_priv.h"

static const char GRID_SMART_NAME[] = "elm_grid";

typedef struct _Elm_Grid_Smart_Data Elm_Grid_Smart_Data;

#define ELM_GRID_DATA_GET(o, sd) \
  Elm_Widget_Smart_Data * sd = evas_object_smart_data_get(o)

#define ELM_GRID_DATA_GET_OR_RETURN(o, ptr)          \
  ELM_GRID_DATA_GET(o, ptr);                         \
  if (!ptr)                                          \
    {                                                \
       CRITICAL("No widget data for object %p (%s)", \
                o, evas_object_type_get(o));         \
       return;                                       \
    }

#define ELM_GRID_DATA_GET_OR_RETURN_VAL(o, ptr, val) \
  ELM_GRID_DATA_GET(o, ptr);                         \
  if (!ptr)                                          \
    {                                                \
       CRITICAL("No widget data for object %p (%s)", \
                o, evas_object_type_get(o));         \
       return val;                                   \
    }

#define ELM_GRID_CHECK(obj)                                             \
  if (!obj || !elm_widget_type_check((obj), GRID_SMART_NAME, __func__)) \
    return

EVAS_SMART_SUBCLASS_NEW
  (GRID_SMART_NAME, _elm_grid, Elm_Widget_Smart_Class,
  Elm_Widget_Smart_Class, elm_widget_smart_class_get, NULL);

static Eina_Bool
_elm_grid_smart_focus_next(const Evas_Object *obj,
                           Elm_Focus_Direction dir,
                           Evas_Object **next)
{
   Eina_Bool ret;
   const Eina_List *items;
   Eina_List *(*list_free)(Eina_List *list);
   void *(*list_data_get)(const Eina_List *list);

   ELM_GRID_DATA_GET(obj, sd);

   /* Focus chain */
   /* TODO: Change this to use other chain */
   if ((items = elm_widget_focus_custom_chain_get(obj)))
     {
        list_data_get = eina_list_data_get;
        list_free = NULL;
     }
   else
     {
        items = evas_object_grid_children_get(sd->resize_obj);
        list_data_get = eina_list_data_get;
        list_free = eina_list_free;

        if (!items) return EINA_FALSE;
     }

   ret = elm_widget_focus_list_next_get(obj, items, list_data_get, dir, next);

   if (list_free) list_free((Eina_List *)items);

   return ret;
}

static Eina_Bool
_elm_grid_smart_focus_direction(const Evas_Object *obj,
                                const Evas_Object *base,
                                double degree,
                                Evas_Object **direction,
                                double *weight)
{
   Eina_Bool ret;
   const Eina_List *items;
   Eina_List *(*list_free)(Eina_List *list);
   void *(*list_data_get)(const Eina_List *list);

   ELM_GRID_DATA_GET(obj, sd);

   /* Focus chain */
   /* TODO: Change this to use other chain */
   if ((items = elm_widget_focus_custom_chain_get(obj)))
     {
        list_data_get = eina_list_data_get;
        list_free = NULL;
     }
   else
     {
        items = evas_object_grid_children_get(sd->resize_obj);
        list_data_get = eina_list_data_get;
        list_free = eina_list_free;

        if (!items) return EINA_FALSE;
     }

   ret = elm_widget_focus_list_direction_get(obj, base, items, list_data_get,
                                             degree, direction, weight);

   if (list_free) list_free((Eina_List *)items);

   return ret;
}

static void
_mirrored_set(Evas_Object *obj, Eina_Bool rtl)
{
   ELM_GRID_DATA_GET(obj, sd);

   evas_object_grid_mirrored_set(sd->resize_obj, rtl);
}

static Eina_Bool
_elm_grid_smart_theme(Evas_Object *obj)
{
   if (!_elm_grid_parent_sc->theme(obj)) return EINA_FALSE;

   _mirrored_set(obj, elm_widget_mirrored_get(obj));

   return EINA_TRUE;
}

static void
_elm_grid_smart_add(Evas_Object *obj)
{
   EVAS_SMART_DATA_ALLOC(obj, Elm_Widget_Smart_Data);

   priv->resize_obj = evas_object_grid_add(evas_object_evas_get(obj));
   evas_object_grid_size_set(priv->resize_obj, 100, 100);

   _elm_grid_parent_sc->base.add(obj);

   elm_widget_can_focus_set(obj, EINA_FALSE);

   _elm_grid_smart_theme(obj);
}

static void
_elm_grid_smart_del(Evas_Object *obj)
{
   Eina_List *l;
   Evas_Object *child;

   ELM_GRID_DATA_GET(obj, sd);

   /* let's make our grid object the *last* to be processed, since it
    * may (smart) parent other sub objects here */
   EINA_LIST_FOREACH (sd->subobjs, l, child)
     {
        if (child == sd->resize_obj)
          {
             sd->subobjs = eina_list_demote_list(sd->subobjs, l);
             break;
          }
     }

   _elm_grid_parent_sc->base.del(obj);
}

static void
_elm_grid_smart_set_user(Elm_Widget_Smart_Class *sc)
{
   sc->base.add = _elm_grid_smart_add;
   sc->base.del = _elm_grid_smart_del;

   sc->theme = _elm_grid_smart_theme;
   sc->focus_next = _elm_grid_smart_focus_next;
   sc->focus_direction = _elm_grid_smart_focus_direction;
}

EAPI Evas_Object *
elm_grid_add(Evas_Object *parent)
{
   Evas_Object *obj;

   EINA_SAFETY_ON_NULL_RETURN_VAL(parent, NULL);

   obj = elm_widget_add(_elm_grid_smart_class_new(), parent);
   if (!obj) return NULL;

   if (!elm_widget_sub_object_add(parent, obj))
     ERR("could not add %p as sub object of %p", obj, parent);

   return obj;
}

EAPI void
elm_grid_size_set(Evas_Object *obj,
                  Evas_Coord w,
                  Evas_Coord h)
{
   ELM_GRID_CHECK(obj);
   ELM_GRID_DATA_GET(obj, sd);

   evas_object_grid_size_set(sd->resize_obj, w, h);
}

EAPI void
elm_grid_size_get(const Evas_Object *obj,
                  Evas_Coord *w,
                  Evas_Coord *h)
{
   ELM_GRID_CHECK(obj);
   ELM_GRID_DATA_GET(obj, sd);

   evas_object_grid_size_get(sd->resize_obj, w, h);
}

EAPI void
elm_grid_pack(Evas_Object *obj,
              Evas_Object *subobj,
              Evas_Coord x,
              Evas_Coord y,
              Evas_Coord w,
              Evas_Coord h)
{
   ELM_GRID_CHECK(obj);
   ELM_GRID_DATA_GET(obj, sd);

   elm_widget_sub_object_add(obj, subobj);
   evas_object_grid_pack(sd->resize_obj, subobj, x, y, w, h);
}

EAPI void
elm_grid_unpack(Evas_Object *obj,
                Evas_Object *subobj)
{
   ELM_GRID_CHECK(obj);
   ELM_GRID_DATA_GET(obj, sd);

   elm_widget_sub_object_del(obj, subobj);
   evas_object_grid_unpack(sd->resize_obj, subobj);
}

EAPI void
elm_grid_clear(Evas_Object *obj,
               Eina_Bool clear)
{
   Eina_List *chld;
   Evas_Object *o;

   ELM_GRID_CHECK(obj);
   ELM_GRID_DATA_GET(obj, sd);

   if (!clear)
     {
        chld = evas_object_grid_children_get(sd->resize_obj);
        EINA_LIST_FREE (chld, o)
          elm_widget_sub_object_del(obj, o);
     }

   evas_object_grid_clear(sd->resize_obj, clear);
}

EAPI void
elm_grid_pack_set(Evas_Object *subobj,
                  Evas_Coord x,
                  Evas_Coord y,
                  Evas_Coord w,
                  Evas_Coord h)
{
   Evas_Object *obj = elm_widget_parent_widget_get(subobj);

   ELM_GRID_CHECK(obj);
   ELM_GRID_DATA_GET(obj, sd);

   evas_object_grid_pack(sd->resize_obj, subobj, x, y, w, h);
}

EAPI void
elm_grid_pack_get(Evas_Object *subobj,
                  int *x,
                  int *y,
                  int *w,
                  int *h)
{
   Evas_Object *obj = elm_widget_parent_widget_get(subobj);

   ELM_GRID_CHECK(obj);
   ELM_GRID_DATA_GET(obj, sd);

   evas_object_grid_pack_get(sd->resize_obj, subobj, x, y, w, h);
}

EAPI Eina_List *
elm_grid_children_get(const Evas_Object *obj)
{
   ELM_GRID_CHECK(obj) NULL;
   ELM_GRID_DATA_GET(obj, sd);

   return evas_object_grid_children_get(sd->resize_obj);
}
