package helpers
{
	import org.apache.royale.net.HTTPService;
	import org.apache.royale.net.HTTPConstants;
	import org.apache.royale.events.EventDispatcher;
	import org.apache.royale.net.events.ResultEvent;
	import org.apache.royale.net.events.FaultEvent;

	[Event(name="complete",type="helpers.ServiceCompleteEvent")]
	[Event(name="ioError",type="helpers.ServiceIOErrorEvent")]
	public class ServiceFactory extends EventDispatcher
	{
        private static const ENDPOINT:String = "<REPLACE_ENDPOINT>/";

        public static const COMPLETE:String = "complete";
        public static const IOERROR:String = "ioError";

        public function get(url:String):void
        {
            call(HTTPConstants.GET, url);
        }

        public function post(url:String):void
        {
            call(HTTPConstants.POST, url);
        }

        private function call(method:String, url:String):void
        {
            var service:HTTPService = new HTTPService();
            service.url = ENDPOINT + url;
            service.method = method;
            service.addEventListener(COMPLETE, function(event:ResultEvent):void { callback(event) });
            service.addEventListener(IOERROR, function(event:FaultEvent):void { dispatchEvent(new ServiceIOErrorEvent(event.message.toString())) });
            service.send();
        }

        private function callback(event:ResultEvent):void
        {
            if (event.currentTarget.data != '')
                dispatchEvent(new ServiceCompleteEvent(event.currentTarget.json));
            else
                dispatchEvent(new ServiceIOErrorEvent("not available!"));
        }
	}
}