using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class ServiceAttachApproval
    {
        private string Enduser_Name;
        private string Reseller_Name;
        private string Distributor_Name;
        private int Supplier_id;
        private int MainType_Id;
        private int Category_Id;
        private int Product_Id;
        private int Quantity;
        private string Total_Period;
        private string Competitor_Name;
        private decimal UPSWOutDcnt_Dstbtrprice;
        private decimal UPSWOutDcnt_Rsprice;
        private decimal UPSWOutDcnt_Euprice;
        private decimal UPSWDcnt_DstbtrPrice;
        private decimal UPSWDcnt_Rsprice;
        private decimal UPSWDcnt_Euprice;
        private decimal USAWOutDcnt_Dstbtrprice;
        private decimal USAWOutDcnt_Rsprice;
        private decimal USAWOutDcnt_Euprice;
        private decimal USAWDcnt_DstbtrPrice;
        private decimal USAWDcnt_Rsprice;
        private decimal USAWDcnt_Euprice;
        private DateTime? Warrenty=null;
        private string SAFilename;
        private string SAFilepath;
        private string SASignedFilename;
        private string SASignedFilePath;
        private int SPA;
        public string P_EnduserName
        {
            set { Enduser_Name = value; }
            get { return Enduser_Name; }
        }
        public string P_ResellerName
        {
            set { Reseller_Name = value; }
            get { return Reseller_Name; }
        }
        public string P_DistributorName
        {
            set { Distributor_Name = value; }
            get { return Distributor_Name; }
        }
        public int P_Supplierid
        {
            set { Supplier_id = value; }
            get { return Supplier_id; }
        }
        public int P_MainTypeId
        {
            set { MainType_Id = value; }
            get { return MainType_Id; }
        }
        public int P_CategoryId
        {
            set { Category_Id = value; }
            get { return Category_Id; }
        }
        public int P_ProductId
        {
            set { Product_Id = value; }
            get { return Product_Id; }
        }
        public int P_Quantity
        {
            set { Quantity = value; }
            get { return Quantity; }
        }
        public string P_TotalPeriod
        {
            set { Total_Period = value; }
            get { return Total_Period; }
        }
        public string P_CompetitorName
        {
            set { Competitor_Name = value; }
            get { return Competitor_Name; }
        }
        public decimal P_UPSWOutDcnt_Dstbtrprice
        {
            set { UPSWOutDcnt_Dstbtrprice = value; }
            get { return UPSWOutDcnt_Dstbtrprice; }
        }
        public decimal P_UPSWOutDcnt_Rsprice
        {
            set { UPSWOutDcnt_Rsprice = value; }
            get { return UPSWOutDcnt_Rsprice; }
        }
        public decimal P_UPSWOutDcnt_Euprice
        {
            set { UPSWOutDcnt_Euprice = value; }
            get { return UPSWOutDcnt_Euprice; }
        }
        public decimal P_UPSWDcnt_DstbtrPrice
        {
            set { UPSWDcnt_DstbtrPrice = value; }
            get { return UPSWDcnt_DstbtrPrice; }

        }
        public decimal P_UPSWDcnt_Rsprice
        {
            set { UPSWDcnt_Rsprice = value; }
            get { return UPSWDcnt_Rsprice; }
        }
        public decimal P_UPSWDcnt_Euprice
        {
            set { UPSWDcnt_Euprice = value; }
            get { return UPSWDcnt_Euprice; }
        }
        public decimal P_USAWOutDcnt_Dstbtrprice
        {
            set { USAWOutDcnt_Dstbtrprice = value; }
            get { return USAWOutDcnt_Dstbtrprice; }
        }
        public decimal P_USAWOutDcnt_Rsprice
        {
            set { USAWOutDcnt_Rsprice = value; }
            get { return USAWOutDcnt_Rsprice; }
        }
        public decimal P_USAWOutDcnt_Euprice
        {
            set { USAWOutDcnt_Euprice = value; }
            get { return USAWOutDcnt_Euprice; }
        }
        public decimal P_USAWDcnt_DstbtrPrice
        {
            set { USAWDcnt_DstbtrPrice = value; }
            get { return USAWDcnt_DstbtrPrice; }
        }
        public decimal P_USAWDcnt_Rsprice
        {
            set { USAWDcnt_Rsprice = value; }
            get { return USAWDcnt_Rsprice; }
        }
        public decimal P_USAWDcnt_Euprice
        {
            set { USAWDcnt_Euprice = value; }
            get { return USAWDcnt_Euprice; }
        }
        public DateTime? P_Warrenty
        {
            set { Warrenty = value; }
            get { return Warrenty; }
        }
        public string P_SAFilename
        {
            set { SAFilename = value; }
            get { return SAFilename; }
        }
        public string P_SAFilepath
        {
            set { SAFilepath = value; }
            get { return SAFilepath; }
        }
        public string P_SASignedFilename
        {
            set { SASignedFilename = value; }
            get { return SASignedFilename; }
        }
        public string P_SASignedFilePath
        {
            set { SASignedFilePath = value; }
            get { return SASignedFilePath; }
        }
        public int P_SPA
        {
            set { SPA = value; }
            get { return SPA; }
        }
    }
}
