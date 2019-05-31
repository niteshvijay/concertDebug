//-----------------------------------------------------------------------
// <copyright file="Transformer1.cs" company="YourCompany">
//     Copyright (c) YourCompany. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Finivation.Concert.Shared;
using System.Linq;
using System.Text;
using System.Data;
using Finivation.Common.Helpers.Serialization;

namespace TransformerProj1
{
    /// <summary>
    /// Transformer class
    /// </summary>
	public class Transformer2 : TransformerBase
    {
        /// <summary>
        /// Transforms the original input 'from' message, and stores the result in the output 'to' message
        /// </summary>
        /// <param name="from">The source message</param>
        /// <param name="to">The transformed message</param>
        /// <param name="option">Options dictionary for controlling the transformation</param>
        /// <param name="populateToMessageMatchingInfo">Bool to indicate matching info on the message will be populated</param>
        /// <returns>null (at present)</returns>
        public override TransformResult Transform(CMessage from, CMessage to, Dictionary<string, string> option, bool populateToMessageMatchingInfo = false)
        {
            Logger.Trace(null, "Transformer 2 called");
            var sqlResponse = SerializationHelper.DeserializeXmlObjectFromBytes<SqlResponse>(from.Data);

            //to.Data = Encoding.UTF8.GetBytes("Response from Transformer2");
            to.Data = from.Data;
            to.MatchingInfo = Guid.NewGuid().ToString();
            to.ExtraHelperInfo["testname"] = "testmessage1";
            //to.AddHttpHeader("HABC", "transfValueA");
            //to.AddHttpHeader("H1", "transfValueB");

            return null;    // Currently returned TransformResult is not used so null is okay
        }

        private void TransformMemberVerify(CMessage from, CMessage to)
        {
            // TO-DO: add application logic here
        }
        private void TransformAccountInquiry(CMessage from, CMessage to)
        {
            // TO-DO: add application logic here
        }

        //Uncomment the code below if you want to implement your own logic for Start/Stop
        //public override void Start(Dictionary<string, Dictionary<string, string>> config)
        //{
        //    base.Start(config);
        //}

        //public override void Stop()
        //{
        //}
    }
}
