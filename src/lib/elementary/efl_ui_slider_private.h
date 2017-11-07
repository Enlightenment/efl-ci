#ifndef EFL_UI_SLIDER_PRIVATE_H
#define EFL_UI_SLIDER_PRIVATE_H

#include "Elementary.h"

/* DO NOT USE THIS HEADER UNLESS YOU ARE PREPARED FOR BREAKING OF YOUR
 * CODE. THIS IS ELEMENTARY'S INTERNAL WIDGET API (for now) AND IS NOT
 * FINAL. CALL elm_widget_api_check(ELM_INTERNAL_API_VERSION) TO CHECK
 * IT AT RUNTIME.
 */

/**
 * @addtogroup Widget
 * @{
 *
 * @section elm-slider-class The Elementary Slider Class
 *
 * Elementary, besides having the @ref Slider widget, exposes its
 * foundation -- the Elementary Slider Class -- in order to create other
 * widgets which are a slider with some more logic on top.
 */

/**
 * Base layout smart data extended with slider instance data.
 */
typedef struct _Efl_Ui_Slider_Data Efl_Ui_Slider_Data;
struct _Efl_Ui_Slider_Data
{
   Evas_Object          *spacer, *popup, *popup2, *track, *track2;
   Ecore_Timer          *delay;

   double                val, val_min, val_max, val2, step;

   Ecore_Timer           *wheel_indicator_timer;
   double                wheel_indicator_duration;
   Elm_Slider_Indicator_Visible_Mode indicator_visible_mode; /**< indicator_visible_mode of the slider.
                                                                This indicates when to show an indicator */

   Evas_Coord            size;
   Evas_Coord            downx, downy;
   Efl_Ui_Dir            dir;

   double                intvl_from, intvl_to;

   Efl_Ui_Format_Func_Cb format_cb;
   Eina_Free_Cb          format_free_cb;
   void                  *format_cb_data;
   Eina_Strbuf           *format_strbuf;

   Efl_Ui_Format_Func_Cb indi_format_cb;
   Eina_Free_Cb          indi_format_free_cb;
   void                  *indi_format_cb_data;
   Eina_Strbuf           *indi_format_strbuf;
   const char            *indi_template;


   Eina_Bool             indicator_show : 1;
   Eina_Bool             spacer_down : 1;
   Eina_Bool             frozen : 1;
   Eina_Bool             units_show : 1;
   Eina_Bool             popup_visible : 1;
   Eina_Bool             intvl_enable : 1;
};

/**
 * @}
 */

#define EFL_UI_SLIDER_DATA_GET(o, sd) \
  Efl_Ui_Slider_Data * sd = efl_data_scope_get(o, EFL_UI_SLIDER_CLASS)

#define EFL_UI_SLIDER_DATA_GET_OR_RETURN(o, sd, ...) \
  Efl_Ui_Slider_Data * sd = efl_data_scope_safe_get(o, EFL_UI_SLIDER_CLASS); \
  if (EINA_UNLIKELY(!sd))                            \
    {                                                \
       ERR("No widget data for object %p (%s)",      \
           o, evas_object_type_get(o));              \
       return __VA_ARGS__;                           \
    }

#endif
