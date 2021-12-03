namespace HeartbeatSharp.Core
{
    /// <summary>
    /// Used for every response from the API.
    /// </summary>
    /// <typeparam name="T">The API object deriving from IApiObject</typeparam>
    public readonly struct ApiResponse<T>
    {
        /// <summary>
        /// The data from the response of the API.
        /// </summary>
        public T? Data { get; }
        
        /// <summary>
        /// If the API call was successful or not. Equivalent than checking if Data is null.
        /// </summary>
        public bool Success { get; }

        public ApiResponse(T? data, bool success)
        {
            Data = data;
            Success = success;
        }
    }
}