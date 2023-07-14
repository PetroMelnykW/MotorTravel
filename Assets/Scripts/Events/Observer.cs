namespace Events
{
    public static class Observer
    {
        public static void Subscribe<T>(System.Action<object, T> func)
        {
            EventHelper<T>.Event += func;
        }

        public static void Unsubscribe<T>(System.Action<object, T> func)
        {
            EventHelper<T>.Event -= func;
        }

        public static void Post<T>(object sender, T eventData)
        {
            EventHelper<T>.Post(sender, eventData);
        }

        private static class EventHelper<T>
        {
            public static event System.Action<object, T> Event;

            public static void Post(object sender, T eventData)
            {
                Event.Invoke(sender, eventData);
            }
        }
    }
}

