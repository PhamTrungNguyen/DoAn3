using DoAn.DTO;
using pbl3.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn.BLL
{
    public class QLBLL
    {
        PBL3QLRPEntities4 db = new PBL3QLRPEntities4();
        private static QLBLL _Instance;
        public static QLBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new QLBLL();
                }
                return _Instance;
            }
            private set { }
        }
        //---------------------------- Phim ----------------------------
        public DinhDangPhim SSThoiGian(string maphim, DateTime dtpPhimNgayKC)
        {
            return db.DinhDangPhims.Where(s => s.IDPhim == maphim && s.LichChieux.OrderBy(p => p.ThoiGianChieu).FirstOrDefault().ThoiGianChieu < dtpPhimNgayKC).FirstOrDefault();
        }
        public DinhDangPhim SSThoiGian1(string maphim, DateTime dtpPhimNgayKT)
        {
            return db.DinhDangPhims.Where(s => s.IDPhim == maphim && s.LichChieux.OrderByDescending(p => p.ThoiGianChieu).FirstOrDefault().ThoiGianChieu > dtpPhimNgayKT).FirstOrDefault();

        }
        public List<PhimDTO> ShowPhim()
        {
            List<PhimDTO> dataphim = new List<PhimDTO>();
            dataphim = (from p in db.Phims
                        select
                new PhimDTO
                {
                    idPhim = p.IDPhim,
                    tenPhim = p.TenPhim,
                    thoiLuong = (double)p.ThoiLuong,
                    ngayKC = (DateTime)p.NgayKhoiChieu,
                    ngayKT = (DateTime)p.NgayKetThuc,
                    sanXuat = p.SanXuat,
                    namSanXuat = (int)p.NamSX,
                    daoDien = p.DaoDien,
                    idTheLoai = p.IDTheLoai,
                }).ToList();
            return dataphim;
        }
        public void DelPhim(string IDPhim)
        {
            foreach (DinhDangPhim i in db.DinhDangPhims)
            {
                if (i.IDPhim == IDPhim)
                {
                    db.DinhDangPhims.Remove(i);
                }
            }
            Phim p = db.Phims.Find(IDPhim);
            db.Phims.Remove(p);
            db.SaveChanges();
        }
        public void ExecuteDBPhim(Phim phim)
        {
            Phim p = db.Phims.Find(phim.IDPhim);
            if (p != null)
            {
                p.IDPhim = phim.IDPhim;
                p.TenPhim = phim.TenPhim;
                p.ThoiLuong = Convert.ToDouble(phim.ThoiLuong);
                p.NgayKhoiChieu = Convert.ToDateTime(phim.NgayKhoiChieu);
                p.NgayKetThuc = Convert.ToDateTime(phim.NgayKetThuc);
                p.SanXuat = phim.SanXuat;
                p.NamSX = Convert.ToInt32(phim.NamSX);
                p.DaoDien = phim.DaoDien;
                p.IDTheLoai = phim.IDTheLoai;

            }
            else
            {
                db.Phims.Add(phim);
            }
            db.SaveChanges();
        }
        public Phim GetPhimByIDPhim(string IDPhim)
        {
            return db.Phims.Find(IDPhim);
        }
        //---------------------------- TheLoai ----------------------------
        public List<TheLoaiDTO> ShowTheLoai()
        {
            List<TheLoaiDTO> datatheloai = new List<TheLoaiDTO>();
            datatheloai = (from p in db.TheLoais
                           select
                   new TheLoaiDTO
                   {
                       ID_TheLoai = p.IDTheLoai,
                       TenTheLoai = p.TenTheLoai,
                   }).ToList();
            return datatheloai;
        }
        public void DelTheLoai(string IDTheLoai)
        {
            foreach (Phim i in db.Phims)
            {

                if (i.IDTheLoai == IDTheLoai)
                {
                    db.Phims.Remove(i);

                }
            }
            TheLoai tl = db.TheLoais.Find(IDTheLoai);
            db.TheLoais.Remove(tl);
            db.SaveChanges();
        }
        public void ExecuteDBTheLoai(TheLoai tl)
        {
            TheLoai theloai = db.TheLoais.Find(tl.IDTheLoai);
            if (theloai != null)
            {
                theloai.IDTheLoai = tl.IDTheLoai;
                theloai.TenTheLoai = tl.TenTheLoai;

            }
            else
            {
                db.TheLoais.Add(tl);
            }
            db.SaveChanges();
        }
        public List<CBBTheLoai> GetCBBTheLoai()
        {
            List<CBBTheLoai> data = new List<CBBTheLoai>();
            foreach (TheLoai i in db.TheLoais)
            {
                data.Add(new CBBTheLoai
                {
                    value = i.IDTheLoai,
                    text = i.TenTheLoai,
                });
            }
            return data;
        }
        public TheLoai GetTheLoaiByIDTheLoai(string IDTheLoai)
        {
            return db.TheLoais.Find(IDTheLoai);
        }
        //---------------------------- DinhDangPhim ----------------------------
        public List<DinhDangPhimDTO> ShowDinhDangPhim()
        {
            List<DinhDangPhimDTO> dataDinhDangPhim = new List<DinhDangPhimDTO>();
            dataDinhDangPhim = (from p in db.DinhDangPhims
                                select
                        new DinhDangPhimDTO
                        {
                            ID_DinhDangPhim = p.IDDinhDangPhim,
                            ID_Phim = p.IDPhim,
                            ID_LoaiManHinh = p.IDLoaiManHinh,
                            MovieName = p.Phim.TenPhim,
                            LMH = p.LoaiManHinh.TenManHinh
                        }).ToList();
            return dataDinhDangPhim;
        }
        public void ExecuteDBDinhDangPhim(DinhDangPhim ddpim)
        {
            DinhDangPhim dinhDangPhim = db.DinhDangPhims.Find(ddpim.IDDinhDangPhim);
            if (dinhDangPhim != null)
            {
                dinhDangPhim.IDDinhDangPhim = ddpim.IDDinhDangPhim;
                dinhDangPhim.IDPhim = ddpim.IDPhim;
                dinhDangPhim.IDLoaiManHinh = ddpim.IDLoaiManHinh;
            }
            else
            {
                db.DinhDangPhims.Add(ddpim);
            }
            db.SaveChanges();
        }
        public void DelDinhDangPhim(string IDDinhDangPhim)
        {
            DinhDangPhim ddphim = db.DinhDangPhims.Find(IDDinhDangPhim);
            foreach (LichChieu i in db.LichChieux)
            {
                if (i.IDDinhDang == IDDinhDangPhim)
                {
                    db.LichChieux.Remove(i);
                }
            }
            db.DinhDangPhims.Remove(ddphim);
             db.SaveChanges();
        }
        public List<CBBPhim> GetCBBPhim()
        {
            List<CBBPhim> data = new List<CBBPhim>();
            foreach (Phim i in db.Phims)
            {
                data.Add(new CBBPhim
                {
                    value = i.IDPhim,
                    text = i.TenPhim,
                });
            }
            return data;
        }
        public List<CBBLoaiManHinh> GetCBBLoaiManHinh()
        {
            List<CBBLoaiManHinh> data = new List<CBBLoaiManHinh>();
            foreach (LoaiManHinh i in db.LoaiManHinhs)
            {
                data.Add(new CBBLoaiManHinh
                {
                    value = i.IDLoaiManHinh,
                    text = i.TenManHinh,
                });
            }
            return data;
        }
        public DinhDangPhim GetDinhDangPhimByMaDinhDang(string IDDinhDangPhim)
        {
            return db.DinhDangPhims.Find(IDDinhDangPhim);
        }
        // -------------------LoaiManHinh-----------------------
      
        public List<LoaiManHinhDTO> ShowLMH()
        {
            List<LoaiManHinhDTO> datalmh = new List<LoaiManHinhDTO>();
            datalmh = (from p in db.LoaiManHinhs
                       select
                       new LoaiManHinhDTO
                       {
                           ID_LoaiManHinh = p.IDLoaiManHinh,
                           TenManHinh = p.TenManHinh,
                       }).ToList();
            return datalmh;
        }
        public void ExecuteDBLoaiMH(LoaiManHinh lmh)
        {
            LoaiManHinh p = db.LoaiManHinhs.Find(lmh.IDLoaiManHinh);
            if (p != null)
            {
                p.IDLoaiManHinh = lmh.IDLoaiManHinh;
                p.TenManHinh = lmh.TenManHinh;
            }
            else
            {
                db.LoaiManHinhs.Add(lmh);
            }
            db.SaveChanges();
        }
        public LoaiManHinh GetLMHByIDLMH(string IDLoaiMH)
        {
            return db.LoaiManHinhs.Find(IDLoaiMH);
        }
        public List<CBBLoaiManHinh> GetCBBLoaiMH()
        {
            List<CBBLoaiManHinh> data = new List<CBBLoaiManHinh>();
            foreach (LoaiManHinh i in db.LoaiManHinhs)
            {
                data.Add(new CBBLoaiManHinh
                {
                    value = i.IDLoaiManHinh,
                    text = i.TenManHinh,
                });
            }
            return data;
        }
        public void DelLoaiMH(string IDLoaiMH)
        {
            foreach (PhongChieu i in db.PhongChieux)
            {
                if (i.IDManHinh == IDLoaiMH)
                {
                    db.PhongChieux.Remove(i);
                }
            }
            foreach (DinhDangPhim d in db.DinhDangPhims)
            {
                if (d.IDLoaiManHinh == IDLoaiMH)
                {
                    db.DinhDangPhims.Remove(d);
                }
            }
            LoaiManHinh lmh = db.LoaiManHinhs.Find(IDLoaiMH);
            db.LoaiManHinhs.Remove(lmh);
            db.SaveChanges();
        }
        public DinhDangPhim GetLMHByDinhDang(string maLMH1)
        {
            return (from p in db.DinhDangPhims 
                    where p.IDLoaiManHinh == maLMH1 
                    select p).FirstOrDefault();
        }
        // -----------------PhongChieu--------------------
        public LichChieu getLichChieuByIDPhong(string idPhong)
        {
            return (from i in db.LichChieux
                    where i.IDPhong == idPhong
                    select i).FirstOrDefault();
        }
        public List<PhongChieuDTO> ShowPhongChieu()
        {
            List<PhongChieuDTO> datapc = new List<PhongChieuDTO>();
            datapc = (from p in db.PhongChieux
                      select
                      new PhongChieuDTO
                      {
                          IDPhongChieu = p.IDPhongChieu,
                          TenPhong = p.TenPhong,
                          IDManHinh = p.IDManHinh,
                          SoChoNgoi = (int)p.SoChoNgoi,
                          //TinhTrang = p.TinhTrang,
                          SoHangGhe = (int)p.SoHangGhe,
                          SoGhe1Hang = (int)p.SoGheMotHang,

                      }).ToList();
            return datapc;
        }
        public void ExecuteDBPhongChieu(PhongChieu pc)
        {
            PhongChieu p = db.PhongChieux.Find(pc.IDPhongChieu);
            if (p != null)
            {
                p.IDPhongChieu = pc.IDPhongChieu;
                p.TenPhong = pc.TenPhong;
                p.IDManHinh = pc.IDManHinh;
                p.SoChoNgoi = Convert.ToInt32(pc.SoChoNgoi);
                p.TinhTrang = pc.TinhTrang;
                p.SoHangGhe = Convert.ToInt32(pc.SoHangGhe);
                p.SoGheMotHang = Convert.ToInt32(pc.SoGheMotHang);
            }
            else
            {
                db.PhongChieux.Add(pc);
            }
            db.SaveChanges();
        }
        public PhongChieu GetPCByIDPC(string IDPhongChieu)
        {
            return db.PhongChieux.Find(IDPhongChieu);
        }
        public void DelPhongChieu(string IDPC)
        {
            foreach (LichChieu i in db.LichChieux)
            {
                if (i.IDPhong == IDPC)
                {
                    db.LichChieux.Remove(i);
                }
            }
            PhongChieu pc = db.PhongChieux.Find(IDPC);
            db.PhongChieux.Remove(pc);
            db.SaveChanges();
        }
        public List<LichChieu> GetPhongChieuByLichChieu(string mapc)
        {
            
            return (from p in db.LichChieux 
                    where p.IDPhong == mapc
                    select p).ToList();
        }
        //-----------------LichChieu------------
        public List<LichChieuDTO> ShowLichChieu()
        {
            List<LichChieuDTO> dataLichChieu = new List<LichChieuDTO>();
            dataLichChieu = (from p in db.LichChieux
                             select
                   new LichChieuDTO
                   {
                       IDLichChieu = p.IDLichChieu,
                       ThoiGianChieu = (DateTime)p.ThoiGianChieu,
                       IDPhong = p.IDPhong,
                       IDDinhDang = p.IDDinhDang,
                       GiaVe = p.GiaVe,
                       TrangThai = p.TrangThai,
                       TenPhong = p.PhongChieu.TenPhong,
                       TenPhim = p.DinhDangPhim.Phim.TenPhim,
                   }).ToList();
            return dataLichChieu;
        }
        public void ExecuteLichChieu(LichChieu l)
        {
                LichChieu lc = db.LichChieux.Find(l.IDLichChieu);
            try
            {
                if (lc != null)
                {
                    lc.IDLichChieu = l.IDLichChieu;
                    lc.IDPhong = l.IDPhong;
                    lc.IDDinhDang = l.IDDinhDang;
                    lc.ThoiGianChieu = l.ThoiGianChieu;
                    lc.GiaVe = l.GiaVe;
                    lc.TrangThai = l.TrangThai == null ? "0" : l.TrangThai ;
                }
                else
                {
                    l.TrangThai = "0";
                    db.LichChieux.Add(l);
                }
                db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show("Thời gian lỗi hoặc lịch chiêu trùng !!!");
                
            }
        }
        public LichChieu GetLCbByIDLC(string idLichChieu)
        {
            return db.LichChieux.Where(a => a.IDLichChieu == idLichChieu).FirstOrDefault();
           
        }
        public string GetIDPhimByTenPhim(string tenPhim)
        {
            return (from p in db.DinhDangPhims
                    where p.Phim.TenPhim == tenPhim
                    select p.IDPhim).FirstOrDefault();
        }

        public List<LichChieu> GetLCByTenPhimVaTrangThai(string tenPhim)
        {
            return (from p in db.LichChieux
                   where p.DinhDangPhim.Phim.TenPhim == tenPhim & p.TrangThai == "1"
                   select p).ToList();
        }
    public void DelLichChieu(string idlc)
        {
            foreach (Ve i in db.Ves)
            {
                if (i.IDLichChieu == idlc)
                {
                    db.Ves.Remove(i);
                }
            }
            LichChieu pc = db.LichChieux.Find(idlc);
            db.LichChieux.Remove(pc);
            db.SaveChanges();
        }
        public List<Ve> LoadVe(string idLichChieu)
        {
            return  (db.Ves.Where(p => p.IDLichChieu == idLichChieu)).ToList();

           
        }
        public List<CBBPhongChieu> GetCBBPhongChieu()
        {
            List<CBBPhongChieu> data = new List<CBBPhongChieu>();
            foreach (PhongChieu i in db.PhongChieux)
            {
                data.Add(new CBBPhongChieu
                {
                    value = i.IDPhongChieu,
                    text = i.TenPhong,
                });
            }
            return data;
        }
        public List<CBBDinhDang> GetCBBDinhDang()
        {
            List<CBBDinhDang> data = new List<CBBDinhDang>();
            foreach (DinhDangPhim i in db.DinhDangPhims)
            {
                data.Add(new CBBDinhDang
                {
                    value = i.IDDinhDangPhim,
                    text = i.IDPhim,
                    text1 = i.IDLoaiManHinh,
                });
            }
            return data;
        }
        // -------------------------DoanhThu--------------------------------
        public DataTable GetRevenue(string idMovie, DateTime fromDate, DateTime toDate)
        {
            return Data.ExecuteQuery("EXEC USP_GetRevenueByMovieAndDate @idMovie , @fromDate , @toDate", new object[] { idMovie, fromDate, toDate });
        }
        public List<LichChieuDTO> GetAllListShowTimes()
        {
            List<LichChieuDTO> listShowTimes = new List<LichChieuDTO>();
            DataTable data = Data.ExecuteQuery("USP_GetAllListShowTimes");
            foreach (DataRow row in data.Rows)
            {
                LichChieuDTO showTimes = new LichChieuDTO(row);
                listShowTimes.Add(showTimes);
            }
            return listShowTimes;
        }
        public List<LichChieuDTO> GetListShowTimesNotCreateTickets()
        {
            List<LichChieuDTO> listShowTimes = new List<LichChieuDTO>();
            DataTable data = Data.ExecuteQuery("USP_GetListShowTimesNotCreateTickets");
            foreach (DataRow row in data.Rows)
            {
                LichChieuDTO showTimes = new LichChieuDTO(row);
                listShowTimes.Add(showTimes);
            }
            return listShowTimes;
        }
        public static PhongChieuDTO GetCinemaByName(string cinemaName)
        {
            string query = "select * from dbo.PhongChieu where TenPhong = '" + cinemaName + "'";
            DataTable data = Data.ExecuteQuery(query);
            return new PhongChieuDTO(data.Rows[0]);
        }
        public int InsertTicketByShowTimes(string showTimesID, string seatName)
        {
            string query = "USP_InsertTicketByShowTimes @idlichChieu , @maGheNgoi";
            return Data.ExecuteNonQuery(query, new object[] { showTimesID, seatName });
        }
        public int UpdateStatusShowTimes(string showTimesID, int status)
        {
            string query = "USP_UpdateStatusShowTimes @idLichChieu , @status";
            return Data.ExecuteNonQuery(query, new object[] { showTimesID, status });
        }
        public void AutoCreateTicketsByShowTimes(LichChieuDTO lichchieu)
        {
            int result = 0;
            PhongChieuDTO phongChieu = GetCinemaByName(lichchieu.IDPhong);
            int Row = phongChieu.SoHangGhe;
            int Column = phongChieu.SoGhe1Hang;
            for (int i = 0; i < Row; i++)
            {
                int temp = i + 65;
                char nameRow = (char)(temp);
                for (int j = 1; j <= Column; j++)
                {
                    string seatName = nameRow.ToString() + j;
                    result += InsertTicketByShowTimes(lichchieu.IDLichChieu, seatName);
                }
            }
            if (lichchieu.TrangThai == "1")
            {
                MessageBox.Show("Lịch chiếu  Đã được tạo!!");
            }
            else if (result == Row * Column)
            {
                int ret = UpdateStatusShowTimes(lichchieu.IDLichChieu, 1);
                if (ret > 0)
                    MessageBox.Show("TẠO VÉ TỰ ĐỘNG THÀNH CÔNG!", "THÔNG BÁO");
            }
            else
                MessageBox.Show("TẠO VÉ TỰ ĐỘNG THẤT BẠI!", "THÔNG BÁO");
        }
        public static int DeleteTicketsByShowTimes(string showTimesID)
        {
            string query = "USP_DeleteTicketsByShowTimes @idlichChieu";
            return Data.ExecuteNonQuery(query, new object[] { showTimesID });
        }
        public void DeleteTicketsByShowTimes(LichChieuDTO showTimes)
        {
            PhongChieuDTO cinema = GetCinemaByName(showTimes.IDPhong);
            int Row = cinema.SoHangGhe;
            int Column = cinema.SoGhe1Hang;

            DeleteTicketsByShowTimes(showTimes.IDLichChieu);
            if (showTimes.TrangThai == "1")
            {
                int ret = UpdateStatusShowTimes(showTimes.IDLichChieu, 0);
                if (ret > 0)
                    MessageBox.Show("XÓA TẤT CẢ CÁC VÉ CỦA LỊCH CHIẾU ID=" + showTimes.IDLichChieu + " THÀNH CÔNG!", "THÔNG BÁO");
            }
            else
            {
                MessageBox.Show("XÓA TẤT CẢ CÁC VÉ CỦA LỊCH CHIẾU ID=" + showTimes.IDLichChieu + " THẤT BẠI!", "THÔNG BÁO");
            }
        }
        public List<Phim> GetPhimByNgayKC_KT(DateTime date)
        {
            List<Phim> dataphim = new List<Phim>();
            try
            {
                dataphim = ((db.Phims.Where(p => date <= p.NgayKetThuc && date >= p.NgayKhoiChieu)).ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dataphim;

        }
        public string GetIDPhim(string name)
        {
            string idphim = "";
            foreach (Phim i in db.Phims)
            {
                if (i.TenPhim == name)
                {
                    idphim = i.IDPhim;
                }
            }
            return idphim;
        }
        //----------------------------------------
        public PhongChieuDTO GetPCBYID(string name)
        {
            string query = "select * from dbo.PhongChieu where TenPhong = '" + name + "'";
            DataTable data = Data.ExecuteQuery(query);
            return new PhongChieuDTO(data.Rows[0]);
        }
        public List<TicketDTO> GetListTicketsByShowTimes(string showTimesID)
        {
            List<TicketDTO> listTicket = new List<TicketDTO>();
            string query = "select * from Ve where idLichChieu = '" + showTimesID + "'";
            DataTable data = Data.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                TicketDTO ticket = new TicketDTO(row);
                listTicket.Add(ticket);
            }
            return listTicket;
        }
        public List<DinhDangPhimDTO> GetListFormatMovieByMovie(string movieID)
        {
            List<DinhDangPhimDTO> listFormat = new List<DinhDangPhimDTO>();
            string query = "select d.IDDinhDangPhim, p.IDPhim, m.IDLoaiManHinh " +
           "from Phim p, DinhDangPhim d, LoaiManHinh m " +
           "where p.IDDinhDangPhim = d.IDPhim and d.IDLoaiManHinh = m.IDDinhDangPhim "
           + "and p.IDDinhDangPhim = '" + movieID + "'";
            DataTable data = Data.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                DinhDangPhimDTO format = new DinhDangPhimDTO(row);
                listFormat.Add(format);
            }
            return listFormat;
        }
        public DataTable GetCustomer(string id, string name)
        {
            string query = "Select * from KhachHang where idKhachHang = '" + id + "' and HoTenKH = N'" + name + "'";
            return Data.ExecuteQuery(query);
        }

        // La khach hang thanh vien
        public int BuyTicket(string ticketID, int type, string customerID, float price)
        {
            string query = "Update dbo.Ve set TrangThai = 1, LoaiVe = " + type
                + ", IDKhachHang =N'" + customerID + "', TienBanVe =" + price + " where IDVe = '" + ticketID + "'";
            return Data.ExecuteNonQuery(query);
        }
        // Khong la khach hang thanh vien
        public int BuyTicket(string ticketID, int type, float price)
        {
            string query = "Update dbo.Ve set TrangThai = 1, LoaiVe = "
                + type + ", TienBanVe =" + price + " where IDVe = '" + ticketID + "'";
            return Data.ExecuteNonQuery(query);
        }
        public bool UpdatePointCustomer(string id, int point)
        {
            string command = string.Format("UPDATE dbo.KhachHang SET  DiemTichLuy = {0} WHERE idKhachHang = '{1}'", point, id);
            int result = Data.ExecuteNonQuery(command);
            return result > 0;
        }
        //--------NhanVien-----------
        public List<NhanVienDTO> ShowNhanVien()
        {
            List<NhanVienDTO> datanv = new List<NhanVienDTO>();
            datanv = (from p in db.NhanViens
                      select
                      new NhanVienDTO
                      {
                          IDNhanVien = p.idNhanVien,
                          NameNV = p.TenNV,
                          NS = (DateTime)p.NgaySinhNV,
                          DiaChi = p.DiaChiNV,
                          SDT = p.SDTNV,
                          CMND = (int)p.CMNDNV,
                      }).ToList();
            return datanv;
        }
        public void ExecuteDBNV(NhanVien nv)
        {
            NhanVien p = db.NhanViens.Find(nv.idNhanVien);
            if (p != null)
            {
                p.idNhanVien = nv.idNhanVien;
                p.TenNV = nv.TenNV;
                p.NgaySinhNV = Convert.ToDateTime(nv.NgaySinhNV);
                p.DiaChiNV = nv.DiaChiNV;
                p.SDTNV = nv.SDTNV;
                p.CMNDNV = Convert.ToInt32(nv.CMNDNV);
            }
            else
            {
                db.NhanViens.Add(nv);
            }
            db.SaveChanges();
        }
        public NhanVien GetNVByIDNV(string IDNV)
        {
            return db.NhanViens.Find(IDNV);
        }
        public List<CBBNhanVien> GetCBBNhanVien()
        {
            List<CBBNhanVien> data = new List<CBBNhanVien>();
            foreach (NhanVien i in db.NhanViens)
            {
                data.Add(new CBBNhanVien
                {
                    value = i.idNhanVien,
                    text = i.TenNV,
                });
            }
            return data;
        }
        public void DelNV(string IDNV)
        {
            foreach (TaiKhoan i in db.TaiKhoans)
            {
                if (i.idNhanVien == IDNV)
                {
                    db.TaiKhoans.Remove(i);
                }
            }
            NhanVien nv = db.NhanViens.Find(IDNV);
            db.NhanViens.Remove(nv);
            db.SaveChanges();
        }
        public List<NhanVienDTO> SearchNhanVien(string txt)
        {
            List<NhanVienDTO> data = db.NhanViens.Where(p => p.TenNV.Contains(txt)).Select(p => new NhanVienDTO
            {
                IDNhanVien = p.idNhanVien,
                NameNV = p.TenNV,
                NS = (DateTime)p.NgaySinhNV,
                DiaChi = p.DiaChiNV,
                SDT = p.SDTNV,
                CMND = (int)p.CMNDNV,
            }).ToList();
            return data;
        }
        //-------KhachHang--------
        public List<KhachHangDTO> ShowKhachHang()
        {
            List<KhachHangDTO> datakh = new List<KhachHangDTO>();
            datakh = (from p in db.KhachHangs
                      select new KhachHangDTO
                      {
                          ID = p.idKhachHang,
                          Ten = p.HoTenKH,
                          NgaySinh = (DateTime)p.NgaySinhKH,
                          DiaChiKH = p.DiaChiKH,
                          SDT = p.SDTKH,
                          CMND = p.CMNDKH,
                          DiemTichLuy = (int)(p.DiemTichLuy),
                      }).ToList();
            return datakh;
        }
        public void ExecuteDBKH(KhachHang kh)
        {
            KhachHang p = db.KhachHangs.Find(kh.idKhachHang);
            if (p != null)
            {
                p.idKhachHang = kh.idKhachHang;
                p.HoTenKH = kh.HoTenKH;
                p.NgaySinhKH = kh.NgaySinhKH;
                p.DiaChiKH = kh.DiaChiKH;
                p.SDTKH = kh.SDTKH;
                p.CMNDKH = kh.CMNDKH;
                p.DiemTichLuy = kh.DiemTichLuy;
            }
            else
            {
                db.KhachHangs.Add(kh);
            }
            db.SaveChanges();
        }

        public KhachHang GetKHByIDKH(string IDKH)
        {
            return db.KhachHangs.Find(IDKH);
        }
        public void DelKH(string IDKH)
        {
            KhachHang kh = db.KhachHangs.Find(IDKH);
            db.KhachHangs.Remove(kh);
            db.SaveChanges();
        }
        public List<KhachHangDTO> SearchKhachHang(string txt)
        {
            List<KhachHangDTO> data = db.KhachHangs.Where(p => p.HoTenKH.Contains(txt)).Select(p => new KhachHangDTO
            {
                ID = p.idKhachHang,
                Ten = p.HoTenKH,
                NgaySinh = p.NgaySinhKH,
                DiaChiKH = p.DiaChiKH,
                SDT = p.SDTKH,
                CMND = p.CMNDKH,
                DiemTichLuy = p.DiemTichLuy,
            }).ToList();
            return data;
        }
        //--------------------------------TaiKhoan------------------------------
        public List<TaiKhoanDTO> ShowTaiKhoan()
        {
            List<TaiKhoanDTO> datatk = new List<TaiKhoanDTO>();
            datatk = (from p in db.TaiKhoans
                      select
                      new TaiKhoanDTO
                      {
                          userName = p.UserName,
                          passWord = p.Pass,
                          loaiTK = p.LoaiTK,
                          IDNV = p.idNhanVien,
                      }).ToList();
            return datatk;
        }
        public TaiKhoan GetTKByUserName(string userName)
        {
            return db.TaiKhoans.Find(userName);
        }
        public void ExecuteDBTaiKhoan(TaiKhoan tk)
        {
            TaiKhoan p = db.TaiKhoans.Find(tk.UserName);
            if (p != null)
            {
                p.UserName = tk.UserName;
                p.Pass = "123456789";
                p.idNhanVien = tk.idNhanVien;
                p.LoaiTK = tk.LoaiTK;

            }
            else
            {
                db.TaiKhoans.Add(tk);
            }
            db.SaveChanges();
        }
        public void DelTK(string username)
        {
            TaiKhoan tk = db.TaiKhoans.Find(username);
            db.TaiKhoans.Remove(tk);
            db.SaveChanges();
        }
        public List<TaiKhoanDTO> SearchTaiKhoan(string txt)
        {
            List<TaiKhoanDTO> data = db.TaiKhoans.Where(p => p.UserName.Contains(txt)).Select(p => new TaiKhoanDTO
            {
                userName = p.UserName,
                loaiTK = p.LoaiTK,
                IDNV = p.idNhanVien,
                passWord = p.Pass,
            }).ToList();
            return data;
        }
        public int Login(string userName, string passWord)
        {
            string query = "USP_Login @userName , @passWord";
            DataTable result = Data.ExecuteQuery(query, new object[] { userName, passWord });
            if (result == null)
                return -1;
            else if (result.Rows.Count > 0)
                return 1;
            else
                return 0;

        }
        public TaiKhoanDTO GetAccountByUserName(string userName)
        {
            DataTable data = Data.ExecuteQuery("Select * from TaiKhoan where userName = '" + userName + "'");

            foreach (DataRow row in data.Rows)
            {
                return new TaiKhoanDTO(row);
            }

            return null;
        }
        public LichChieu GetLichChieuByID(string id)
        {
            return db.LichChieux.Find(id);
        }

    }
}
