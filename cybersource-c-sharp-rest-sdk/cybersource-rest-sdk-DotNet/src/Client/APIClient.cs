using System;
using System.IO;
using System.Net;
using System.Text;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Cybersource.Api;

namespace Cybersource.Client
{
    public class VisaAPIClient
    {
        private void LogRequest(string url, string requestBody)
        {
            Debug.WriteLine(url);
            Debug.WriteLine(requestBody);
        }

        private void LogResponse(string info, HttpWebResponse response)
        {
            string responseBody;
            Debug.WriteLine(info);
            Debug.WriteLine("Response Status: \n" + response.StatusCode);
            Debug.WriteLine("Response Headers: \n" + response.Headers.ToString());
            
            using (var reader = new StreamReader(response.GetResponseStream(), ASCIIEncoding.ASCII))
            {
                responseBody = reader.ReadToEnd();
            }
            Console.WriteLine("responseBody: " + responseBody);
            Debug.WriteLine("Response Body: \n" + responseBody);
        }

        //Correlation Id ( x-correlation-id ) is an optional header while making an API call. You can skip passing the header while calling the API's.
        private string GetCorrelationId()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 12).Select(s => s[random.Next(s.Length)]).ToArray()) + "_SC";

        }

        private string GetBasicAuthHeader(string userId, string password)
        {
            string authString = userId + ":" + password;
            var authStringBytes = Encoding.UTF8.GetBytes(authString);
            string authHeaderString = Convert.ToBase64String(authStringBytes);
            return "Basic " + authHeaderString;
        }

        public string DoMutualAuthCall(string path, string method, string testInfo, string requestBodyString, Dictionary<string, string> headers = null)
        {
            string requestURL = ConfigurationManager.AppSettings["visaUrl"] + path;
            string userId = ConfigurationManager.AppSettings["userId"];
            string password = ConfigurationManager.AppSettings["password"];
            string certificatePath = ConfigurationManager.AppSettings["cert"];
            string certificatePassword = ConfigurationManager.AppSettings["certPassword"];
            string statusCode = "";
            LogRequest(requestURL, requestBodyString);
            // Create the POST request object 
            HttpWebRequest request = WebRequest.Create(requestURL) as HttpWebRequest;
            request.Method = method;
            if (method.Equals("POST") || method.Equals("PUT"))
            {
                request.ContentType = "application/json";
                request.Accept = "application/json";

                // Load the body for the post request
                var requestStringBytes = Encoding.UTF8.GetBytes(requestBodyString);
                request.GetRequestStream().Write(requestStringBytes, 0, requestStringBytes.Length);
            }

            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    request.Headers[header.Key] = header.Value;
                }
            }
            
            // Add headers
            request.Headers["Authorization"] = GetBasicAuthHeader(userId, password);
            request.Headers["x-correlation-id"] = GetCorrelationId();
            // Add certificate
            var certificate = new X509Certificate2(certificatePath, certificatePassword);
            request.ClientCertificates.Add(certificate);

            try
            {
                // Make the call
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    LogResponse(testInfo, response);
                    statusCode = response.StatusCode.ToString();
                }
            }
            catch (WebException e)
            {
                if (e.Response is HttpWebResponse)
                {
                    HttpWebResponse response = (HttpWebResponse)e.Response;
                    LogResponse(testInfo, response);
                    statusCode = response.StatusCode.ToString();
                }
            }
            return statusCode;
        }

        private IApiAccessor getResource(string []transactionDetails)
        {
            switch (transactionDetails[0])
            {
                case "authorizations":
                    AuthorizationApi auth = new AuthorizationApi(transactionDetails);
                    return auth;

                case "capture":
                    CaptureApi capture = new CaptureApi(transactionDetails);
                    return capture;

                case "sale":
                    SaleApi sale = new SaleApi(transactionDetails);
                    return sale;

                case "refundCapture":
                    RefundCaptureApi refundCapture = new RefundCaptureApi(transactionDetails);
                    return refundCapture;

                case "refundSale":
                    RefundSaleApi refundSale = new RefundSaleApi(transactionDetails);
                    return refundSale;

                case "credit":
                    CreditApi credit = new CreditApi(transactionDetails);
                    return credit;

                case "voidCapture":
                    VoidCaptureApi voidCapture = new VoidCaptureApi(transactionDetails);
                    return voidCapture;

                case "voidSale":
                    VoidSaleApi voidSale = new VoidSaleApi(transactionDetails);
                    return voidSale;

                case "voidRefund":
                    VoidRefundApi voidRefund = new VoidRefundApi(transactionDetails);
                    return voidRefund;

                case "voidCredit":
                    VoidCreditApi voidCredit = new VoidCreditApi(transactionDetails);
                    return voidCredit;

                case "authreversal":
                    AuthReversalApi authreversal = new AuthReversalApi(transactionDetails);
                    return authreversal;

                case "paymentSearch":
                    PaymentSearchApi paymentSearch = new PaymentSearchApi(transactionDetails);
                    return paymentSearch;

                case "paymentSearchId":
                    PaymentSearchIdApi paymentSearchId = new PaymentSearchIdApi(transactionDetails);
                    return paymentSearchId;

                case "retrieveAuth":
                    RetrieveAuthApi retrieveAuth = new RetrieveAuthApi(transactionDetails);
                    return retrieveAuth;

                case "retrieveCapture":
                    RetrieveCaptureApi retrieveCapture = new RetrieveCaptureApi(transactionDetails);
                    return retrieveCapture;

                case "retrieveAuthId":
                    RetrieveAuthIDApi retrieveAuthId = new RetrieveAuthIDApi(transactionDetails);
                    return retrieveAuthId;

                case "searchSale":
                    SearchSaleApi searchSale = new SearchSaleApi(transactionDetails);
                    return searchSale;

                case "retrieveRefund":
                    RetrieveRefundApi retrieveRefund = new RetrieveRefundApi(transactionDetails);
                    return retrieveRefund;

                case "refundCaptureId":
                    RefundCaptureIdApi refundCaptureId = new RefundCaptureIdApi(transactionDetails);
                    return refundCaptureId;

                case "refundSaleID":
                    RefundSaleIdApi refundSaleID = new RefundSaleIdApi(transactionDetails);
                    return refundSaleID;

                case "retieveCredit":
                    RetrieveCreditApi retieveCredit = new RetrieveCreditApi(transactionDetails);
                    return retieveCredit;

                case "retrieveReversal":
                    RetrieveReversalApi reversal = new RetrieveReversalApi(transactionDetails);
                    return reversal;

                case "retrieveVoid":
                    RetrieveVoidApi voidId = new RetrieveVoidApi(transactionDetails);
                    return voidId;

                case "retrieveAllAuth":
                    RetrieveAllAuthApi retrieveAllAuth = new RetrieveAllAuthApi(transactionDetails);
                    return retrieveAllAuth;

                case "retrieveAllCapture":
                    RetrieveAllCaptureApi retrieveAllCapture = new RetrieveAllCaptureApi(transactionDetails);
                    return retrieveAllCapture;

                case "retrieveAllSale":
                    RetrieveAllSaleApi retrieveAllSale = new RetrieveAllSaleApi(transactionDetails);
                    return retrieveAllSale;

                case "retrieveAllRefund":
                    RetrieveAllRefundApi retrieveAllRefund = new RetrieveAllRefundApi(transactionDetails);
                    return retrieveAllRefund;
                case "retrieveAllCredit":
                    RetrieveAllCreditApi retrieveAllCredit = new RetrieveAllCreditApi(transactionDetails);
                    return retrieveAllCredit;

            }
            throw new NotImplementedException();
        }

        public string DoXPayTokenCall(string baseUri, string []transactionDetails, string queryString, string testInfo, string requestBodyString)
        {
            IApiAccessor resource = getResource(transactionDetails);
            string method = resource.GetTransactionType();
            Console.WriteLine(resource.GetTransactionResourcePath());
            string requestURL = ConfigurationManager.AppSettings["visaUrl"] + baseUri + resource.GetTransactionResourcePath() + "?" + queryString;
            string apikey = ConfigurationManager.AppSettings["apiKey"];

            LogRequest(requestURL, requestBodyString);

            // Create the POST/GET request object 
            string statusCode = "";
            string xPayToken = "";
            HttpWebRequest request = WebRequest.Create(requestURL) as HttpWebRequest;
            request.Method = method;
            

            if (method.Equals("POST") || method.Equals("PUT"))
            {
                request.ContentType = "application/json";
                request.Accept = "application/json";

                // Load the body for the post request
                var requestStringBytes = Encoding.UTF8.GetBytes(requestBodyString);
                request.GetRequestStream().Write(requestStringBytes, 0, requestStringBytes.Length);

                xPayToken = GetXPayToken(resource.GetTransactionResourcePath(), "apikey=" + apikey, requestBodyString);
            }
            
            else if (method.Equals("GET"))
            {
                request.ContentType = "application/json";
                request.Accept = "application/json";
                //Get request generate x-pay-token
                xPayToken = GetXPayToken(resource.GetTransactionResourcePath(), "apikey=" + apikey);
            }   

            request.Headers["x-pay-token"] = xPayToken;
            request.Headers["x-correlation-id"] = GetCorrelationId();

            try
            {
                // Make the call
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    LogResponse(testInfo, response);
                    statusCode = response.StatusCode.ToString();
                }
            }
            catch (WebException e)
            {
                if (e.Response is HttpWebResponse)
                {
                    HttpWebResponse response = (HttpWebResponse)e.Response;
                    LogResponse(testInfo, response);
                    statusCode = response.StatusCode.ToString();
                }
            }
            return statusCode;
        }

        private static string GetXPayToken(string apiNameURI, string queryString, string requestBody = "")
        {
            string timestamp = GetTimestamp();
            string sourceString = timestamp + apiNameURI + queryString + requestBody;
            string hash = GetHash(sourceString);
            string token = "xv2:" + timestamp + ":" + hash;
            Console.WriteLine(token);
            return token;
        }

        private static string GetTimestamp()
        {
            long timeStamp = ((long)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds) / 1000;
            return timeStamp.ToString();
        }

        private static string GetHash(string data)
        {
            string sharedSecret = ConfigurationManager.AppSettings["sharedSecret"];
            var hashString = new HMACSHA256(Encoding.ASCII.GetBytes(sharedSecret));
            var hashbytes = hashString.ComputeHash(Encoding.ASCII.GetBytes(data));
            string digest = String.Empty;

            foreach (byte b in hashbytes)
            {
                digest += b.ToString("x2");
            }

            return digest;
        }
    }
}
