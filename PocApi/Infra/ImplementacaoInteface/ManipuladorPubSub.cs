using Dominio.Entidades;
using Dominio.Interfaces;
using Google.Cloud.PubSub.V1;
using Google.Protobuf;
using Infra.ConfiguracoesJSON;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.ImplementacaoInteface
{
	public class ManipuladorPubSub<T> : IManipuladorPubSub<T> where T : class
	{
		public async Task<string> EnviarMensagem(string mensagem)
		{
			var topicName = new TopicName("estudo-ci-cd", "tp-poc-ex");
			string retornoIdMensagem = "";
			PublisherServiceApiClient publisher = PublisherServiceApiClient.Create();

			// Create a message
			var message = new PubsubMessage()
			{
				Data = ByteString.CopyFromUtf8(mensagem)
			};
			//message.Attributes.Add("myattrib", "its value");
			var messageList = new List<PubsubMessage>() { message };

			var response = await publisher.PublishAsync(topicName, messageList);
			foreach (var item in response.MessageIds)
			{
				retornoIdMensagem = item;
			}
			return retornoIdMensagem;
		}



		public async Task<T> LeituraMensagem(string rastreio)
		{
			List<string> retorno = new List<string>();
			var subscriptionName = new SubscriptionName("estudo-ci-cd", "sb-poc-ex");

			var subscription = SubscriberServiceApiClient.Create();

			PullResponse response = await subscription.PullAsync(subscriptionName, true, 10);

			var all = response.ReceivedMessages;
			var mensagem = all.Where(x => x.Message.MessageId.Equals(rastreio)).FirstOrDefault();
			var settings = new JsonSerializerSettings()
			{
				ContractResolver = new ConfiguracoesDeAtributos()
			};
			var objeto = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(mensagem.Message.Data.ToArray(), 0, mensagem.Message.Data.Length), settings);
			

			return objeto;
		}
	}
}
