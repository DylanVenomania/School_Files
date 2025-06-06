def ktra_hople_ccd(cccd):
    return len(cccd) == 12 and cccd.isdigit()

def tinh_gioitinh(cccd):
    province_code = cccd[:3]
    gender_code = cccd[3]

    provinces = {
         "001": "Hà Nội",
        "002": "Hà Giang",
        "004": "Cao Bằng",
        "006": "Bắc Kạn",
        "008": "Tuyên Quang",
        "010": "Lào Cai",
        "011": "Điện Biên",
        "012": "Lai Châu",
        "014": "Sơn La",
        "015": "Yên Bái",
        "017": "Hòa Bình",
        "019": "Thái Nguyên",
        "020": "Lạng Sơn",
        "022": "Quảng Ninh",
        "024": "Bắc Giang",
        "025": "Phú Thọ",
        "026": "Vĩnh Phúc",
        "027": "Bắc Ninh",
        "030": "Hải Dương",
        "031": "Hải Phòng",
        "033": "Hưng Yên",
        "034": "Thái Bình",
        "035": "Hà Nam",
        "036": "Nam Định",
        "037": "Ninh Bình",
        "038": "Thanh Hóa",
        "040": "Nghệ An",
        "042": "Hà Tĩnh",
        "044": "Quảng Bình",
        "045": "Quảng Trị",
        "046": "Thừa Thiên Huế",
        "048": "Đà Nẵng",
        "049": "Quảng Nam",
        "051": "Quảng Ngãi",
        "052": "Bình Định",
        "054": "Phú Yên",
        "056": "Khánh Hòa",
        "058": "Ninh Thuận",
        "060": "Bình Thuận",
        "062": "Kon Tum",
        "064": "Gia Lai",
        "066": "Đắk Lắk",
        "067": "Đắk Nông",
        "068": "Lâm Đồng",
        "070": "Bình Phước",
        "072": "Tây Ninh",
        "074": "Bình Dương",
        "075": "Đồng Nai",
        "077": "Bà Rịa - Vũng Tàu",
        "079": "Hồ Chí Minh",
        "080": "Long An",
        "082": "Tiền Giang",
        "083": "Bến Tre",
        "084": "Trà Vinh",
        "086": "Vĩnh Long",
        "087": "Đồng Tháp",
        "089": "An Giang",
        "091": "Kiên Giang",
        "092": "Cần Thơ",
        "093": "Hậu Giang",
        "094": "Sóc Trăng",
        "095": "Bạc Liêu",
        "096": "Cà Mau",
    }

    if gender_code in ['0', '2'] :
        gender = "Nam"
    elif gender_code in ['1', '3'] :
        gender = "Nữ"
    
    province = provinces.get(province_code, "Không xác định")
    return province, gender

def main():
    cccd = input("Nhập vào số Căn Cước: ")
  
    if ktra_hople_ccd(cccd):
        province, gender = tinh_gioitinh(cccd)
        birth_code = cccd[4:6]

        gender_code = cccd[3]
        if gender_code in ['0', '1'] :
            birth_year = int(birth_code) + 1900 
        elif gender_code in  ['1', '2'] :
            birth_year = int(birth_code) + 2000
        
        print(f"Số căn cước hợp lệ!")
        print(f"Tỉnh: {province}")
        print(f"Giới tính: {gender}")
        print(f"Năm sinh: {birth_year}")
    else:
        print("Số căn cước không hợp lệ! Vui lòng nhập lại!")


if __name__ == "__main__":
    main()