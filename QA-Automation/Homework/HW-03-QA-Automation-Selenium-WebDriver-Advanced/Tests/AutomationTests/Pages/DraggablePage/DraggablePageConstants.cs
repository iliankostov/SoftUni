namespace AutomationTests.Pages.DraggablePage
{
    public static class Constants
    {
        //// Common
        public const string DRAGGABLE_URL = "draggable/";
        public const int WAIT_SECCONDS = 20;

        //// Selectors
        public const string DEFAULT_TAB_SELECTOR = "ui-id-1";
        public const string CONSTRAIN_MOVEMENT_TAB_SELECTOR = "ui-id-2";
        public const string CURSOR_STYLE_TAB_SELECTOR = "ui-id-3";
        public const string EVENTS_TAB_SELECTOR = "ui-id-4";
        public const string DRAGGABLE_AND_SORTABLE_TAB_SELECTOR = "ui-id-5";
        public const string BODY_ELEMENT = "body";
        public const string DEFAULT_DRAG_ELEMENT = "draggable";
        public const string CONSTRAINT_MOVEMENT_ELEMENT = "draggabl2";
        public const string CURSOR_STYLE_ELEMENT = "drag";
        public const string DRAG_EVENT_ELEMENT = "dragevent";
        public const string EVENT_START_ELEMENT = "//*[@id=\"event-start\"]/span[2]";
        public const string EVENT_DRAG_ELEMENT = "//*[@id=\"event-drag\"]/span[2]";
        public const string EVENT_STOP_ELEMENT = "//*[@id=\"event-stop\"]/span[2]";
        public const string DRAGGABLE_BOX_ELEMENT = "draggablebox";
        public const string DRAG_ME_DOWN_ELEMENT = "//*[@id=\"sortablebox\"]/li[6]";
    }
}
