using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyClcks.Models
{
   public  class ClsAddress
    {
        #region Private variables

        private int _mAddressId;
        private string _mAddressLine1;
        private string _mAddressLine2;
        private string _mTown;
        private string _mCounty;
        private string _mPostCode;
        private Guid _mAccessToken;
        #endregion

        #region Constructor
        public ClsAddress()
        {

        }

        #endregion

        #region Properties
        public Guid AccessToken
        {
            get { return this._mAccessToken; }
            set { this._mAccessToken = value; }
        }
        public int AddressID
        {
            get { return this._mAddressId; }
            set { this._mAddressId = value; }
        }

        public string AddressLine1
        {
            get { return this._mAddressLine1; }
            set { this._mAddressLine1 = value; }
        }

        public string AddressLine2
        {
            get { return this._mAddressLine2; }
            set { this._mAddressLine2 = value; }
        }

        public string Town
        {
            get { return this._mTown; }
            set { this._mTown = value; }
        }

        public string County
        {
            get { return this._mCounty; }
            set { this._mCounty = value; }
        }

        public string PostCode
        {
            get { return this._mPostCode; }
            set { this._mPostCode = value; }
        }
        #endregion
    }
 
}
