package LogicalView;


/**
 * @author hoang
 * @version 1.0
 * @created 30-Thg8-2025 10:31:15 SA
 */
public abstract class Hinh {

	protected string ten;
	protected Diem m_diem[];

	public Hinh(){

	}

	public void finalize() throws Throwable {

	}
	public string docTen(){
		return "";
	}

	/**
	 * 
	 * @param ten
	 */
	public void ganTen(string ten){

	}

	public Diem[] getdiem(){
		return m_Diem;
	}

	/**
	 * 
	 * @param newVal
	 */
	public void setdiem(Diem newVal[]){
		m_Diem = newVal;
	}

	public abstract double tinhChuVi();

	public abstract double tinhDienTich();
}//end Hinh