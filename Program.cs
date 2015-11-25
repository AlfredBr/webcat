// Copyright (c) 2015 Alfred Broderick 
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal 
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is 
// furnished to do so, subject to the following conditions: 
// 
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software. 
// 
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE. using System.Reflection;

using System;
using System.Linq;
using System.Net;

namespace webcat
{
    internal class Program
    {
        private static Uri _uri;
        private static string _format;

        private static void Main(string[] args)
        {
            if (!args.Any())
            {
                return;
            }

            var arg = args[0].ToLower();
            if (arg == @"/help" || arg == "/?")
            {
                Console.WriteLine("Usage: webcat url [format]");
                Console.WriteLine("\n\tformat may be any one of: csv, txt, xml, json, html, binary\n\tor an explicit media type.");
                Console.WriteLine("\n\tSee https://www.iana.org/assignments/media-types/media-types.xhtml");
                return;
            }

            if (args.Any())
            {
                _uri = new Uri(args[0]);
            }

            _format = "TXT"; // this is the default

            if (args.Length > 1)
            {
                _format = args[1] ?? string.Empty;
            }

            try
            {
                var webClient = new WebClient();
                webClient.Headers.Add("Content-Type", GetContentType(_format));
                webClient.UseDefaultCredentials = true;

                string result = webClient.DownloadString(_uri);
                
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        
        private static string GetContentType(string format)
        {
            switch (format.ToLower())
            {
                case "csv":
                    return "text/csv";
                case "txt":
                    return "text/plain";
                case "xml":
                    return "text/xml";
                case "json":
                    return "application/json";
                case "html":
                    return "text/html";
                case "binary":
                    return "application/octet-stream";
                default:
                    return format;
            }
        }
    }
}