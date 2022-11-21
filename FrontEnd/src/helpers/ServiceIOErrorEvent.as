package helpers
{	
	import org.apache.royale.events.Event;

	public class ServiceIOErrorEvent extends Event
	{
        public var message:String;
		
		public function ServiceIOErrorEvent(message:String)
		{
			super("ioError");
            this.message = message;
		}
	}
}