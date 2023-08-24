using Microsoft.Extensions.Configuration;
using OrisonFeeAnalysis.Entities.Financial.Main;
using OrisonFeeAnalysis.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OrisonFeeAnalysis.Services
{
    
    public class FinVoucherEntryService
    {
        private string BaseUrl;
        HttpClient http = new HttpClient();
        private readonly IConfiguration _config;
        public FinVoucherEntryService(HttpClient httpClient,IConfiguration config)
        {
            http = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }
        public async Task<ObservableCollection<dtfinVEntry>> GenerateVoucherEntry(Cheque[] ChecqVE, int ObCustomer, long vID, string Descrptn, string CrDr, Decimal? totAmount, string Rowstate)
        {
            ObservableCollection<dtfinVEntry> objVE = new ObservableCollection<dtfinVEntry>();
            //Decimal? totAmount = 0;
            int SlNo = 0;

            foreach (var item in ChecqVE)
            {
                dtfinVEntry objVEnt = new dtfinVEntry();
                objVEnt.VID = vID;
                objVEnt.SlNo = item.SlNo;
                objVEnt.RowType = item.Status;
                objVEnt.AccountID = item.BankID;
                objVEnt.Description = item.Description;
                objVEnt.Commission = item.Commission;
                objVEnt.ID = item.VEID;
                if (item.Status == "Dr")
                {
                    objVEnt.Debit = item.Amount;
                    objVEnt.Credit = null;
                }
                else
                {
                    objVEnt.Debit = null;
                    objVEnt.Credit = item.Amount;
                }
                objVEnt.Reference = null;
                objVEnt.RefID = null;
                objVEnt.VisibleonPrint = Convert.ToBoolean(1);
                objVEnt.Reconciled = Convert.ToBoolean(0);
                objVEnt.Active = Convert.ToBoolean(1);
                objVEnt.Action = "C";
                objVEnt.UserTrackID = null;
                objVEnt.TranType = item.Trantype;
                objVEnt.InvDate = null;
                objVEnt.InvDate = null;
                objVEnt.TRNNo = null;
                objVEnt.SupName = null;
                objVEnt.VAT = null;
                objVEnt.Taxable = null;
                objVEnt.RowState = item.RowState;

                objVE.Add(objVEnt);
                SlNo++;
                // totAmount = totAmount + item.Amount;
            }

            dtfinVEntry objVEpayee = new dtfinVEntry();
            objVEpayee.VID = vID;
            objVEpayee.RowType = CrDr;
            objVEpayee.AccountID = ObCustomer;
            if (Descrptn == " " || Descrptn == null)
            {
                objVEpayee.Description = "Payment";
            }
            else
            {
                objVEpayee.Description = Descrptn;
            }
            if (CrDr == "Cr")
            {
                objVEpayee.Debit = null;
                objVEpayee.Credit = totAmount;
            }
            else
            {
                objVEpayee.Debit = totAmount;
                objVEpayee.Credit = null;
            }

            objVEpayee.Reference = null;
            objVEpayee.RefID = null;
            objVEpayee.VisibleonPrint = Convert.ToBoolean(1);
            objVEpayee.Reconciled = Convert.ToBoolean(0);
            objVEpayee.Active = Convert.ToBoolean(1);
            objVEpayee.Action = "C";
            objVEpayee.UserTrackID = null;
            objVEpayee.TranType = "Payee";
            objVEpayee.InvDate = null;
            objVEpayee.InvDate = null;
            objVEpayee.TRNNo = null;
            objVEpayee.SupName = null;
            objVEpayee.VAT = null;
            objVEpayee.Taxable = null;
            objVEpayee.RowState = "Insert";

            objVE.Add(objVEpayee);
            //foreach(var item in DedChrg)
            //{
            //    dtfinVEntry obj = new dtfinVEntry();
            //    obj.VID = vID;
            //    obj.SlNo = item.SlNo;
            //    obj.RowType = item.Status;
            //    obj.AccountID = item.BankID;
            //   // obj.Description = item.Description;
            //    if (item.Status == "Dr")
            //    {
            //        obj.Debit = item.Amount;
            //        obj.Credit = null;
            //    }
            //    else
            //    {
            //        obj.Debit = null;
            //        obj.Credit = item.Amount;
            //    }
            //    obj.Reference = null;
            //    obj.RefID = null;
            //    obj.VisibleonPrint = Convert.ToBoolean(1);
            //    obj.Reconciled = Convert.ToBoolean(0);
            //    obj.Active = Convert.ToBoolean(1);
            //    obj.Action = "C";
            //    obj.UserTrackID = null;
            //    obj.TranType = item.Trantype;
            //    obj.InvDate = null;
            //    obj.InvDate = null;
            //    obj.TRNNo = null;
            //    obj.SupName = null;
            //    obj.VAT = null;
            //    obj.Taxable = null;
            //    obj.RowState = "Insert";
            //    objVE.Add(obj);
            //    SlNo++;
            //}


            return objVE;
        }
        public async Task<ObservableCollection<dtfinVEntry>> CreateVoucherEntry(IList<dtfinVEntry> DtVoucherEntryOld, Cheque[] ChecqVE, int ObCustomer, long vID, string Descrptn, string CrDr, Decimal? totAmount, string Rowstate)
        {
            dtfinVEntry[] DtVoucherEntrNew = GenerateVoucherEntry(ChecqVE, ObCustomer, vID, Descrptn, CrDr, totAmount, Rowstate).Result.ToArray();

            dtfinVEntry sr = new dtfinVEntry();
            ObservableCollection<dtfinVEntry> objVE = new ObservableCollection<dtfinVEntry>();
            ObservableCollection<dtfinVEntry> DelArray = new ObservableCollection<dtfinVEntry>();


            if (DtVoucherEntryOld != null && DtVoucherEntryOld.Count() > 0)
            {
                foreach (dtfinVEntry dtnew in DtVoucherEntrNew)
                {
                    sr = DtVoucherEntryOld.Where(T => T.TranType == "Payee" && T.AccountID == dtnew.AccountID).FirstOrDefault();
                    if (dtnew.TranType == "Payee")
                    {
                        dtnew.ID = sr.ID;
                        dtnew.RowState = "Update";
                    }
                }
            }

            //DtVoucherEntryOld = null;

            if (DtVoucherEntrNew != null && DtVoucherEntrNew.Count() > 0)
            {
                if (DtVoucherEntryOld != null && DtVoucherEntryOld.Count() > 0)
                {

                    foreach (dtfinVEntry dtOld in DtVoucherEntryOld)
                    {
                        sr = DtVoucherEntrNew.Where(T => T.AccountID == dtOld.AccountID && T.TranType == dtOld.TranType).FirstOrDefault();
                        if (sr == null)
                        {
                            dtOld.RowState = "Delete";
                            objVE.Add(dtOld);
                            //DtTransactionsOld.Remove(dtOld);
                        }
                    }
                    foreach (dtfinVEntry Del in objVE)
                    {
                        DtVoucherEntryOld.Remove(Del);
                    }
                    if (DtVoucherEntryOld.Count() > 0)
                    {
                        foreach (dtfinVEntry dtNew in DtVoucherEntrNew)
                        {
                            sr = DtVoucherEntryOld.Where(T => T.AccountID == dtNew.AccountID && T.TranType == dtNew.TranType && dtNew.ID == T.ID).FirstOrDefault();
                            if (sr == null)
                            {
                                objVE.Add(dtNew);
                            }
                            else
                            {
                                sr.RowState = "Update";
                                sr.RowType = dtNew.RowType;
                                sr.Debit = dtNew.Debit;
                                sr.SlNo = dtNew.SlNo;
                                sr.Credit = dtNew.Credit;
                                sr.Description = dtNew.Description;
                                sr.TranType = dtNew.TranType;
                                objVE.Add(sr);
                            }
                        }
                    }
                }
                else
                {
                    foreach (dtfinVEntry dtNew in DtVoucherEntrNew)
                    {
                        objVE.Add(dtNew);
                    }
                }
            }
            else if (DtVoucherEntryOld.Count() > 0)
            {
                foreach (dtfinVEntry dtOld in DtVoucherEntryOld)
                {
                    dtOld.RowState = "Delete";
                    objVE.Add(dtOld);
                }
            }
            return objVE;
        }
    }
}
