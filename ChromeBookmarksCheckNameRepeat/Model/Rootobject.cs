namespace ChromeBookmarksCheck.Model
{
    public class Rootobject
    {
        public string checksum { get; set; }
        public Roots roots { get; set; }
        public int version { get; set; }
    }

    public class Roots
    {
        public Bookmark_Bar bookmark_bar { get; set; }
        public Other other { get; set; }
        public Synced synced { get; set; }
    }

    public class Bookmark_Bar
    {
        public Child[] children { get; set; }
        public string date_added { get; set; }
        public string date_modified { get; set; }
        public string guid { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

    public class Child
    {
        public string date_added { get; set; }
        public string guid { get; set; }
        public string id { get; set; }
        public Meta_Info meta_info { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public Child[] children { get; set; }
        public string date_modified { get; set; }
    }

    public class Meta_Info
    {
        public string last_visited_desktop { get; set; }
    }

    public class Other
    {
        public object[] children { get; set; }
        public string date_added { get; set; }
        public string date_modified { get; set; }
        public string guid { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

    public class Synced
    {
        public object[] children { get; set; }
        public string date_added { get; set; }
        public string date_modified { get; set; }
        public string guid { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }
}
