namespace MovieLibrary.Singleton
{
    public enum ErrorCode
    {
        DefaultError = 0,
        NullUser = 1,
        NullParameter= 2,
        NullMovie = 3,
        NullActor = 4,
    }

    public static class ErrorCodes
    {
        public static Dictionary<int, string> Messages { get; set; } = new Dictionary<int, string>()
        {
            [(int)ErrorCode.DefaultError] = "Default error",
            [(int)ErrorCode.NullUser] = "Null exception in AppUsers",
            [(int)ErrorCode.NullParameter] = "Null parameter given",
            [(int)ErrorCode.NullMovie] = "Null exception in Movies",
            [(int)ErrorCode.NullActor] = "Null exception in Actors",
        };
    }
}
