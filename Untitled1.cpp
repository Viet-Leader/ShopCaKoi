#include<iostream>
#include<string> 
#include <iomanip>
#include <vector>
#include<algorithm> 
using namespace std;

class SinhVien {
public:
    int maSoSinhVien;
    string name;
};
int menu() {
    int chon;
    system("cls");
    cout << "\n----QUAN LY THONG TIN SINH VIEN----" << endl;
    cout << "1. Nhap thong tin sinh vien" << endl;
    cout << "2. Hien thi toan bo danh sach sinh vien" << endl;
    cout << "3. Sua thong tin sinh vien" << endl;
    cout << "4. Xoa thong tin sinh vien" << endl; 
    cout << "5. Tim kiem thong tin sinh vien theo ma sinh vien" << endl;
    cout << "6. Sap xep thong tin sinh vien theo ten" << endl;
    cout << "0. Thoat chuong trinh" << endl;
    cout << "-----------------------------" << endl;
    cout << "Nhap lua chon cua ban: ";
    cin >> chon;
    return chon;
}
void addDefaultSV(SinhVien*& sinhVien, int& n);
void info(SinhVien*& sinhVien, int& n);
void add(SinhVien*& sinhVien, int& n);
void del(SinhVien*& sinhVien, int& n);
void searchSV(SinhVien*& sinhVien, int& n);
void editSV(SinhVien*& sinhVien, int& n);
void sortSVByName(SinhVien*& sinhVien, int& n);

int main() {
    int n = 0; 
    SinhVien* sinhVien = nullptr;
    addDefaultSV(sinhVien, n);
    while (true)
    {
        int luaChon = menu();
        switch (luaChon) 
        {
        case 1:
           add(sinhVien,n);
            break;
        case 2:
            info(sinhVien,n);
            break;
        case 3:
            editSV(sinhVien,n);
            break;
        case 4:
            del(sinhVien,n) ;
            break;
        case 5:
            searchSV(sinhVien,n);
            break;
        case 6:
			sortSVByName(sinhVien,n);
			break;
        case 0:
            cout << "Thoat chuong trinh thanh cong!" << endl;
            break;
        default:
            cout << "Lua chon cua ban khong hop le!" << endl;
        }
       cout << "\nBan co muon tiep tuc khong?(Y/N) ";
		char a;
		cin >> a;

		if (a!='Y') {
  		 break;
}
    } 
    delete[] sinhVien;
    return 0; 
}	

void addDefaultSV(SinhVien*& sinhVien, int& n)
{
	SinhVien defaultSV[] = {
        {001,"Tran Quoc Viet"},{002,"Nguyen Tran Anh Yeu Em"},{003,"Phan Le Anh Xin Loi"} 
  };

    int numDefaultSV = sizeof(defaultSV) / sizeof(defaultSV[0]);

    int new_n = n + numDefaultSV;
    SinhVien* sv_tmp = new SinhVien[new_n];

    for (int i = 0; i < n; i++) {
        sv_tmp[i] = sinhVien[i];
    }

    for (int i = 0; i < numDefaultSV; i++) {
        sv_tmp[n + i] = defaultSV[i];
    }

    delete[] sinhVien;
    sinhVien = sv_tmp;

    n = new_n;
}
void info(SinhVien*& sinhVien, int& n)
{
	 system("cls");
        for (int i = 0; i < n; i++) {
            cout<<i+1<<". MSSV: "<< left << setw(20)  << sinhVien[i].maSoSinhVien<<"		" << "Ten SV: " << sinhVien[i].name << endl;
        }
}
void add(SinhVien*& sinhVien, int& n)
{
	system("cls");
    SinhVien new_sinhVien;
    cout << "Them thong tin sinh vien \n";
    cout << "Ma so sinh vien: ";
    cin >> new_sinhVien.maSoSinhVien;
    cin.ignore();

    cout << "Ten sinh vien: ";
    getline(cin, new_sinhVien.name);
    
    int new_n = n + 1;
    SinhVien* sinhVien_tmp = new SinhVien[new_n];

    for (int i = 0; i < n; i++) {
        sinhVien_tmp[i] = sinhVien[i];
    }

    sinhVien_tmp[new_n - 1] = new_sinhVien;
    delete[] sinhVien;
    sinhVien = sinhVien_tmp;

    n = new_n;
    cout << "Them thong tin sinh vien thanh cong!\n";
}
void del(SinhVien*& sinhVien, int& n)
{
	system("cls");
    string delete_sinhVien_mssv;
    cout << "Nhap ten sinh vien can xoa: ";

    cin.ignore();
    getline(cin, delete_sinhVien_mssv);

    int k = -1;
    for (int i = 0; i < n; i++) {
        if (!delete_sinhVien_mssv.compare(sinhVien[i].name)) {
            k = i;
            break;
        }
    }

    if (k == -1) {
        cout << "Khong tim thay sinh vien!!!\n";
        return;
    }

    for (int i = k; i < n - 1; i++) {
        sinhVien[i] = sinhVien[i + 1];
    }

    n--;

    SinhVien* new_sinhVien = new SinhVien[n];
    for (int i = 0; i < n; i++) {
        new_sinhVien[i] = sinhVien[i];
    }
    delete[] sinhVien;
    sinhVien = new_sinhVien;

    cout << "Da xoa sinh vien khoi danh sach!\n";

}
void searchSV(SinhVien*& sinhVien, int& n)
{
	system("cls");
    string searchQuery;
    cout << "Nhap tu khoa tim kiem: ";
    cin.ignore();
    getline(cin, searchQuery);

    bool found = false;

    cout << "Ket qua tim kiem:\n";
    for (int i = 0; i < n; ++i) {
        if (to_string(sinhVien[i].maSoSinhVien).find(searchQuery) != string::npos ||
			sinhVien[i].name.find(searchQuery) != string::npos ) {

            found = true;
            cout << "MSSV: " << sinhVien[i].maSoSinhVien << endl;
            cout << "Ten Sinh Vien: " << sinhVien[i].name << endl;
            cout << "---------------------------\n";
        }
    }

    if (!found) {
        cout << "Khong tim thay ket qua phu hop!\n";
    }
}
void editSV(SinhVien*& sinhVien, int& n)
{
	system("cls");
    string nameSV;
    cout << "Nhap ten sinh vien can sua thong tin: ";
    cin.ignore();
    getline(cin, nameSV);

    int index = -1;
    for (int i = 0; i < n; ++i) {
        if (sinhVien[i].name == nameSV) {
            index = i;
            break;
        }
    }

    if (index == -1) {
        cout << "Khong tim thay sinh vien co ten nay!!!\n";
        return;
    }

    cout << "Thong tin hien tai cua sinh vien:\n";
    cout << "  MSSV: " << sinhVien[index].maSoSinhVien << endl;
    cout << "  Ten Sinh Vien: " << sinhVien[index].name << endl;
    
    cout << "Nhap thong tin moi cho sinh vien:\n";
    cout << "MSSV: ";
    cin>> sinhVien[index].maSoSinhVien;

    cout << "Ten Sinh Vien: ";
    cin.ignore() ;
    getline(cin, sinhVien[index].name);

    cout << "Thong tin sinh vien da duoc cap nhat thanh cong!\n";
}

void sortSVByName(SinhVien*& sinhVien, int& n)
{
sort(sinhVien, sinhVien + n, [](const SinhVien& a, const SinhVien& b) {
        return a.name.length() < b.name.length();
    });
 
 for (int i = 0; i < n; i++) {
            cout<<i+1<<". MSSV: "<< left << setw(20)  << sinhVien[i].maSoSinhVien<<"		" << "Ten SV: " << sinhVien[i].name << endl;
        }
}



