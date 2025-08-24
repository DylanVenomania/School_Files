import java.util.ArrayList;  
import javax.swing.JOptionPane; 

class Node {
    String name;  
    int soluong;  

 
    Node(String name, int soluong) {
        this.name = name;
        this.soluong = soluong;
    }

    
    void display() {
        println("Ten hang hoa: " + name + " | So luong: " + soluong);
    }
}


class DanhSachNode {
    ArrayList<Node> ds;  


    DanhSachNode() {
        ds = new ArrayList<Node>();
    }

  
    void insertEnd(Node node) {
        ds.add(node);
    }


    void deleteFirst() 
    {
        if (!ds.isEmpty()) 
        {
            ds.remove(0);
            println("Da xoa hang hoa o dau danh sach!");
        } 
        else 
            println("Danh sach rong !");
        
    }

    
    Node find(String tenhang) 
    {
        for (Node node : ds) 
        {
            if (node.name.equalsIgnoreCase(tenhang)) 
                return node;  
        }
        return null;
    }

    
    void display() 
    {
        if (ds.isEmpty()) 
            println("Danh sach rong !");
        else 
        {
            for (Node node : ds) 
                node.display();
        }
    }

    
    void updateSoluong(String tenhang, int soluong_new) 
    {
        Node foundNode = find(tenhang);
        if (foundNode != null) {
            foundNode.soluong = soluong_new;
            println("Thanh cong cap nhat so luong cho hang hoa : " + tenhang);
        } 
        else 
            println("Khong tim thay hang hoa : " + tenhang + " trong danh sach !");
    }
}


DanhSachNode ds;


void setup() 
{
    ds = new DanhSachNode(); 
    
    inputData();
}


void inputData() {
    while (true) 
    {
        String choice = JOptionPane.showInputDialog(null, 
            "Chon thao tac:\n" +
            "1: Them hang hoa\n" +
            "2: Xoa hang hoa o dau danh sach\n" +
            "3: Tim kiem hang hoa trong danh sach\n" +
            "4: Cap nhat danh sach\n" +
            "5: Hien thi danh sach\n" +
            "6: Thoat");

        if (choice == null) 
            break; 
        

        int option = Integer.parseInt(choice); 

        switch (option) 
        {
            case 1: 
                String name = JOptionPane.showInputDialog("Nhap ten hang hoa :");
                String quantityStr = JOptionPane.showInputDialog("Nhap so luong :");
                int quantity = Integer.parseInt(quantityStr);
                Node node = new Node(name, quantity);
                ds.insertEnd(node);
                break;
            case 2: 
                ds.deleteFirst();
                break;
            case 3: 
                String tenTim = JOptionPane.showInputDialog("Nhap ten hang hoa can tim:");
                Node foundNode = ds.find(tenTim);
                if (foundNode != null) 
                    foundNode.display();
                else 
                    JOptionPane.showMessageDialog(null, "Khong tim thay hang hoa !");
                break;
            case 4: 
                String tenCapNhat = JOptionPane.showInputDialog("Nhap ten hang hoa muon cap nhat :");
                String soluongMoiStr = JOptionPane.showInputDialog("Nhap so luong moi muon cap nhat :");
                int soluongMoi = Integer.parseInt(soluongMoiStr);
                ds.updateSoluong(tenCapNhat, soluongMoi);
                break;
            case 5: 
                ds.display();
                break;
            case 6: 
                println("Thoat chuong trinh !");
                exit(); 
                return;
            default:
                JOptionPane.showMessageDialog(null, "Lua chon khong hop le !");
                break;
        }
    }
}
