package ChoMuonSach;


/**
 * @author hoang
 * @version 1.0
 * @created 30-Thg8-2025 12:35:43 CH
 */
public class Sach {

	private string maSach;
	private string tenSach;
	private string tacGia;
	private int namXuatBan;
	private boolean tinhTrang;

	public Sach(){

	}

	public void finalize() throws Throwable {

	}
	public string getThongTin(){
		return "Mã: " + maSach + ", Tên: " + tenSach + ", Tác giả: " + tacGia;
	}

	/**
	 * 
	 * @param tinhtrang    tinhtrang
	 */
	public void capNhatTinhTrang(boolean tinhtrang){

	}
	public boolean isAvailable() {
    		return tinhTrang;
	}
}//end Sach