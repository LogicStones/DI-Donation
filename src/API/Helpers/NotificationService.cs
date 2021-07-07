using FirebaseNet.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Helpers
{
	public class NotificationService
	{
		public static async Task SendSingleNotification(FCMClient client, string messageKey, Dictionary<string, string> dic, string deviceToken)
		{
			var message = new Message()
			{
				To = deviceToken,
				Notification = new IOSNotification
				{
					TitleLocKey = messageKey,
					Title = dic["msgTitle"],
					Body = dic["msgBody"]
				}
			};

			var message1 = new Message()
			{
				To = deviceToken,
				Notification = new AndroidNotification
				{
					TitleLocKey = messageKey,
					Title = dic["msgTitle"],
					Body = dic["msgBody"]
				}
				//,
				//Data = new Dictionary<string, string>
				//{
				//	{ "messageKey", messageKey },
				//	{ "data", JsonConvert.SerializeObject(dic) }
				//}
			};

			await client.SendMessageAsync(message);
			await client.SendMessageAsync(message1);
		}

		public static async Task SendBulkNotification(FCMClient client, string messageKey, Dictionary<string, string> dic, ICollection<string> deviceTokens)
		{
			var message = new Message()
			{
				RegistrationIds = deviceTokens,
				Notification = new IOSNotification
				{
					TitleLocKey = messageKey,
					Title = dic["msgTitle"],
					Body = dic["msgBody"]
				}
			};

			var message1 = new Message()
			{
				RegistrationIds = deviceTokens,
				Notification = new AndroidNotification
				{
					TitleLocKey = messageKey,
					Title = dic["msgTitle"],
					Body = dic["msgBody"]
				}
				//,
				//Data = new Dictionary<string, string>
				//{
				//	{ "messageKey", messageKey },
				//	{ "data", JsonConvert.SerializeObject(dic) }
				//}
			};

			await client.SendMessageAsync(message);
			await client.SendMessageAsync(message1);
		}
	}
}