namespace Degreed.DadJokes.CoreTests.Mocks
{
    public class MockHttpContent
    {
        public static string MockJokeHttpContent => "{\"id\":\"ap4orcpGtrc\",\"joke\":\"A man walks into a bar and orders helicopter flavor chips. The barman replies \\u201csorry mate we only do plain\\u201d\",\"status\":200}\n";

        public static string MockJokesHttpContent => "{\"current_page\":1,\"limit\":30,\"next_page\":1,\"previous_page\":1,\"results\":[{\"id\":\"d21DAXSCljb\",\"joke\":\"How does a French skeleton say hello? Bone-jour.\"},{\"id\":\"ysHQZvcpbFd\",\"joke\":\"\\\"Dad, I'm hungry.\\\" Hello, Hungry. I'm Dad.\"}],\"search_term\":\"hello\",\"status\":200,\"total_jokes\":2,\"total_pages\":1}\n";
    }
}
