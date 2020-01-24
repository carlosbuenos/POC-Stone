using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infra.AcessoBaseDados.ChaveSecretaGCP
{
	public class AcessarChave
	{
		private static GoogleCredential credential;
		public static GoogleCredential RetornarCredenciais()
		{
			if (credential == null)
			{
				using (var jsonStream = new FileStream("pubsubbigquery.json", FileMode.Open, FileAccess.Read, FileShare.Read))
					credential = GoogleCredential.FromStream(jsonStream);
			}
			return credential;
		}
	}
}
