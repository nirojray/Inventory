using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class SpecialPriceApproval
    {
        private string SANumber;
        private int SA_Id;
        private string Enduser_Name;
        private string Reseller_Name;
        private string Distributor_Name;
        private int Supplier_id;
        private int MainType_Id;
        private int Category_Id;
        private int Product_Id;
        private int Quantity;
        private decimal UPPWOutDcnt_Dstbtrprice;
        private decimal UPPWOutDcnt_Rsprice;
        private decimal UPPWOutDcnt_EUprice;
        private decimal SUPReq_Dstbtrprice;
        private decimal SUPReq_Rsprice;
        private decimal SUPReq_Euprice;
        private decimal AUP_Dstbtrprice;
        private decimal AUP_Rsprice;
        private decimal AUP_Euprice;
        private decimal VSP_Dstbtrprice;
        private decimal VSP_Rsprice;
        private decimal VSP_Euprice;
        private int ServiceAttach;
        private int SAAppend;
        private DateTime ? ValidPOplacement=null;
        private string SPAAttachFileName;
        private string SPAAttachFilePath;
        private string SPAAttachSignedFileName;
        private string SPAAttcahSignedFilePath;

        private string CUPMake1;
        private string CUPModel1;
        private decimal CUPMake1_Dstbtrprice;
        private decimal CUPMake1_Rsprice;
        private decimal CUPMake1_Euprice;

        private string CUPMake2;
        private string CUPModel2;
        private decimal CUPMake2_Dstbtrprice;
        private decimal CUPMake2_Rsprice;
        private decimal CUPMake2_Euprice;

        public string P_SANumber
        {
            set { SANumber = value; }
            get { return SANumber; }
        }
        public int P_SA_Id
        {
            set { SA_Id = value; }
            get { return SA_Id; }
        }
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
        public decimal P_UPPWOutDcnt_Dstbtrprice
        {
            set { UPPWOutDcnt_Dstbtrprice = value; }
            get { return UPPWOutDcnt_Dstbtrprice; }
        }
        public decimal P_UPPWOutDcnt_Rsprice
        {
            set { UPPWOutDcnt_Rsprice = value; }
            get { return UPPWOutDcnt_Rsprice; }
        }
        public decimal P_UPPWOutDcnt_EUprice
        {
            set { UPPWOutDcnt_EUprice = value; }
            get { return UPPWOutDcnt_EUprice; }
        }
        public decimal P_SUPReq_Dstbtrprice
        {
            set { SUPReq_Dstbtrprice = value; }
            get { return SUPReq_Dstbtrprice; }
        }
        public decimal P_SUPReq_Rsprice
        {
            set { SUPReq_Rsprice = value; }
            get { return SUPReq_Rsprice; }
        }
        public decimal P_SUPReq_Euprice
        {
            set { SUPReq_Euprice = value; }
            get { return SUPReq_Euprice; }
        }
        public decimal P_AUP_Dstbtrprice
        {
            set { AUP_Dstbtrprice = value; }
            get { return AUP_Dstbtrprice; }
        }
        public decimal P_AUP_Rsprice
        {
            set { AUP_Rsprice = value; }
            get { return AUP_Rsprice; }
        }
        public decimal P_AUP_Euprice
        {
            set { AUP_Euprice = value; }
            get { return AUP_Euprice; }
        }
        public decimal P_VSP_Dstbtrprice
        {
            set { VSP_Dstbtrprice = value; }
            get { return VSP_Dstbtrprice; }
        }
        public decimal P_VSP_Rsprice
        {
            set { VSP_Rsprice = value; }
            get { return VSP_Rsprice; }
        }
        public decimal P_VSP_Euprice
        {
            set { VSP_Euprice = value; }
            get { return VSP_Euprice; }
        }
        public int P_ServiceAttach
        {
            set { ServiceAttach = value; }
            get { return ServiceAttach; }
        }
        public int P_SAAppend
        {
            set { SAAppend = value; }
            get { return SAAppend; }
        }
        public DateTime ? P_ValidPOplacement
        {
            set { ValidPOplacement = value; }
            get { return ValidPOplacement; }
        }
        public string P_SPAAttachFileName
        {
            set { SPAAttachFileName = value; }
            get { return SPAAttachFileName; }
        }
        public string P_SPAAttachFilePath
        {
            set { SPAAttachFilePath = value; }
            get { return SPAAttachFilePath; }
        }
        public string P_SPAAttachSignedFileName
        {
            set { SPAAttachSignedFileName = value; }
            get { return SPAAttachSignedFileName; }
        }
        public string P_SPAAttcahSignedFilePath
        {
            set { SPAAttcahSignedFilePath = value; }
            get { return SPAAttcahSignedFilePath; }
        }

        public string P_CUPMake1
        {
            set { CUPMake1 = value; }
            get { return CUPMake1; }
        }
        public string P_CUPModel1
        {
            set { CUPModel1 = value; }
            get { return CUPModel1; }
        }
        public decimal P_CUPMake1_Dstbtrprice
        {
            set { CUPMake1_Dstbtrprice = value; }
            get { return CUPMake1_Dstbtrprice; }
        }
        public decimal P_CUPMake1_Rsbtrprice
        {
            set { CUPMake1_Rsprice = value; }
            get { return CUPMake1_Rsprice; }
        }
        public decimal P_CUPMake1_Euprice
        {
            set { CUPMake1_Euprice = value; }
            get { return CUPMake1_Euprice; }
        }

        public string P_CUPMake2
        {
            set { CUPMake2 = value; }
            get { return CUPMake2; }
        }
        public string P_CUPModel2
        {
            set { CUPModel2 = value; }
            get { return CUPModel2; }
        }
        public decimal P_CUPMake2_Dstbtrprice
        {
            set { CUPMake2_Dstbtrprice = value; }
            get { return CUPMake2_Dstbtrprice; }
        }
        public decimal P_CUPMake2_Rsbtrprice
        {
            set { CUPMake2_Rsprice = value; }
            get { return CUPMake2_Rsprice; }
        }
        public decimal P_CUPMake2_Euprice
        {
            set { CUPMake2_Euprice = value; }
            get { return CUPMake2_Euprice; }
        }

    }
}
