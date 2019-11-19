using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aircraft.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRetrieval()
        {
            try
            {
                var client = ServiceClient.GetClient();

                //Test add new jet.
                int Id = client.Persist(-1, "Falcon 7X", "005");

                //Edit existing jet.
                client.Persist(Id, "Falcon 8X", "005");

                //Retrieve
                var data = client.Retrieve();

                if (data.Length > 0)
                {
                    Assert.IsTrue(client.Remove(Id));
                }
                else
                {
                    Assert.Fail();
                }
                
            }
            catch
            {
                Assert.Fail();
            }
            
        }
    }
}
