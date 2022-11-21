package helpers
{	
	import org.apache.royale.events.Event;

	public class ServiceCompleteEvent extends Event
	{
        public var data:*;
		
		public function ServiceCompleteEvent(data:*)
		{
			super("complete");
            this.data = data;
		}
	}
}