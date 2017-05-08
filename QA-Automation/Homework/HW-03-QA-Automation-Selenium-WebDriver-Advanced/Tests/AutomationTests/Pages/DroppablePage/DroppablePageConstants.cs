namespace AutomationTests.Pages.DroppablePage
{
    public static class Constants
    {
        //// Common
        public const string DROPPABLE_URL = "droppable/";
        public const int WAIT_SECCONDS = 20;

        //// Selectors
        public const string DEFAULT_TAB_SELECTOR = "ui-id-1";
        public const string ACCEPT_TAB_SELECTOR = "ui-id-2";
        public const string PREVENT_PROPAGATION_TAB_SELECTOR = "ui-id-3";
        public const string REVERT_DRAGGABLE_POSITION_TAB_SELECTOR = "ui-id-4";
        public const string SHOPING_CART_DEMO_TAB_SELECTOR = "ui-id-5";
        public const string DRAGGABLE_VIEW_SELECTOR = "draggableview";
        public const string DROPPABLE_VIEW_SELECTOR = "//*[@id=\"droppableview\"]/p";
        public const string DRAGGABLE_NON_VALID_SELECTOR = "draggable-nonvalid";
        public const string DROPPABLE_ACCEPT_SELECTOR = "//*[@id=\"droppableaccept\"]/p";
        public const string DRAGGABLE_PROP_SELECTOR = "draggableprop";
        public const string INNER_DROPPABLE_GREEDY_SELECTOR = "//*[@id=\"droppable2-inner\"]/p";
        public const string OUTER_DROPPABLE_SELECTOR = "//*[@id=\"droppableprop2\"]/p";
        public const string DRAGGABLE_REVERT_SELECTOR = "draggablerevert";
        public const string DROPPABLE_REVERT_SELECTOR = "//*[@id=\"droppablerevert\"]/p";
        public const string PRODUCT_SELECTOR = "//*[@id=\"ui-id-7\"]/ul/li[3]";
        public const string SHOPPING_CART_SELECTOR = "//*[@id=\"cart\"]/div/ol/li";

        //// Labels
        public const string DROPPED = "Dropped!";
    }
}
