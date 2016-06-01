﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.9.7.0
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

using System;
using System.Linq;
using Deleeteme.Models;
using Newtonsoft.Json.Linq;

namespace Deleeteme.Models
{
    public partial class Title
    {
        private double? _advance;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public double? Advance
        {
            get { return this._advance; }
            set { this._advance = value; }
        }
        
        private string _notes;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string Notes
        {
            get { return this._notes; }
            set { this._notes = value; }
        }
        
        private double? _price;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public double? Price
        {
            get { return this._price; }
            set { this._price = value; }
        }
        
        private string _pubID;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string PubID
        {
            get { return this._pubID; }
            set { this._pubID = value; }
        }
        
        private DateTimeOffset? _pubdate;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public DateTimeOffset? Pubdate
        {
            get { return this._pubdate; }
            set { this._pubdate = value; }
        }
        
        private Publisher _publisher;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public Publisher Publisher
        {
            get { return this._publisher; }
            set { this._publisher = value; }
        }
        
        private int? _royalty;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? Royalty
        {
            get { return this._royalty; }
            set { this._royalty = value; }
        }
        
        private string _titleID;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public string TitleID
        {
            get { return this._titleID; }
            set { this._titleID = value; }
        }
        
        private string _title1;
        
        /// <summary>
        /// Required.
        /// </summary>
        public string Title1
        {
            get { return this._title1; }
            set { this._title1 = value; }
        }
        
        private string _type;
        
        /// <summary>
        /// Required.
        /// </summary>
        public string Type
        {
            get { return this._type; }
            set { this._type = value; }
        }
        
        private int? _ytdSales;
        
        /// <summary>
        /// Optional.
        /// </summary>
        public int? YtdSales
        {
            get { return this._ytdSales; }
            set { this._ytdSales = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the Title class.
        /// </summary>
        public Title()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the title class with required
        /// arguments.
        /// </summary>
        public Title(string title1, string type)
            : this()
        {
            if (title1 == null)
            {
                throw new ArgumentNullException("title1");
            }
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            this.Title1 = title1;
            this.Type = type;
        }
        
        /// <summary>
        /// Deserialize the object
        /// </summary>
        public virtual void DeserializeJson(JToken inputObject)
        {
            if (inputObject != null && inputObject.Type != JTokenType.Null)
            {
                JToken advanceValue = inputObject["advance"];
                if (advanceValue != null && advanceValue.Type != JTokenType.Null)
                {
                    this.Advance = ((double)advanceValue);
                }
                JToken notesValue = inputObject["notes"];
                if (notesValue != null && notesValue.Type != JTokenType.Null)
                {
                    this.Notes = ((string)notesValue);
                }
                JToken priceValue = inputObject["price"];
                if (priceValue != null && priceValue.Type != JTokenType.Null)
                {
                    this.Price = ((double)priceValue);
                }
                JToken pubIDValue = inputObject["pub_id"];
                if (pubIDValue != null && pubIDValue.Type != JTokenType.Null)
                {
                    this.PubID = ((string)pubIDValue);
                }
                JToken pubdateValue = inputObject["pubdate"];
                if (pubdateValue != null && pubdateValue.Type != JTokenType.Null)
                {
                    this.Pubdate = ((DateTimeOffset)pubdateValue);
                }
                JToken publisherValue = inputObject["publisher"];
                if (publisherValue != null && publisherValue.Type != JTokenType.Null)
                {
                    Publisher publisher = new Publisher();
                    publisher.DeserializeJson(publisherValue);
                    this.Publisher = publisher;
                }
                JToken royaltyValue = inputObject["royalty"];
                if (royaltyValue != null && royaltyValue.Type != JTokenType.Null)
                {
                    this.Royalty = ((int)royaltyValue);
                }
                JToken titleIDValue = inputObject["title_id"];
                if (titleIDValue != null && titleIDValue.Type != JTokenType.Null)
                {
                    this.TitleID = ((string)titleIDValue);
                }
                JToken title1Value = inputObject["title1"];
                if (title1Value != null && title1Value.Type != JTokenType.Null)
                {
                    this.Title1 = ((string)title1Value);
                }
                JToken typeValue = inputObject["type"];
                if (typeValue != null && typeValue.Type != JTokenType.Null)
                {
                    this.Type = ((string)typeValue);
                }
                JToken ytdSalesValue = inputObject["ytd_sales"];
                if (ytdSalesValue != null && ytdSalesValue.Type != JTokenType.Null)
                {
                    this.YtdSales = ((int)ytdSalesValue);
                }
            }
        }
        
        /// <summary>
        /// Serialize the object
        /// </summary>
        /// <returns>
        /// Returns the json model for the type title
        /// </returns>
        public virtual JToken SerializeJson(JToken outputObject)
        {
            if (outputObject == null)
            {
                outputObject = new JObject();
            }
            if (this.Title1 == null)
            {
                throw new ArgumentNullException("Title1");
            }
            if (this.Type == null)
            {
                throw new ArgumentNullException("Type");
            }
            if (this.Advance != null)
            {
                outputObject["advance"] = this.Advance.Value;
            }
            if (this.Notes != null)
            {
                outputObject["notes"] = this.Notes;
            }
            if (this.Price != null)
            {
                outputObject["price"] = this.Price.Value;
            }
            if (this.PubID != null)
            {
                outputObject["pub_id"] = this.PubID;
            }
            if (this.Pubdate != null)
            {
                outputObject["pubdate"] = this.Pubdate.Value;
            }
            if (this.Publisher != null)
            {
                outputObject["publisher"] = this.Publisher.SerializeJson(null);
            }
            if (this.Royalty != null)
            {
                outputObject["royalty"] = this.Royalty.Value;
            }
            if (this.TitleID != null)
            {
                outputObject["title_id"] = this.TitleID;
            }
            if (this.Title1 != null)
            {
                outputObject["title1"] = this.Title1;
            }
            if (this.Type != null)
            {
                outputObject["type"] = this.Type;
            }
            if (this.YtdSales != null)
            {
                outputObject["ytd_sales"] = this.YtdSales.Value;
            }
            return outputObject;
        }
    }
}
