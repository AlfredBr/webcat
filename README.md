# webcat
Simply downloads bytes from a URL

Webcat can support (almost) any datatype that the target server will provide.  
(Technically, webcat does not know anything about the data it receives.)

Webcat takes a third argument as shorthand to make it easier to request popular formats from the server, 
but webcat is in no way limited to these formats:

csv:      "text/csv"
txt:       "text/plain"
xml:      "text/xml"
json:     "application/json"
html:     "text/html"
binary:  “application/octet-stream"

The default is TXT, so for example, this will send “Content-Type: text/plain”

C:\> webcat “http://www.anyplaceyouwant.com/this/is/a/test”

Which is the same as this

C:\> webcat “http://www.anyplaceyouwant.com/this/is/a/test” txt

Additionally, rather than using the shorthand, you can explicitly specify any Content-Type string you want, such as

C:\> webcat “http://www.anyplaceyouwant.com/this/is/a/test” “text/html”

Or

C:\> webcat “http://www.anyplaceyouwant.com/this/is/a/test” “something/elseentirely”
