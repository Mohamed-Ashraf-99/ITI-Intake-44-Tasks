#include <iostream>
#include "GeoShape.h"
#include "Rectangle.h"
#include "Square.h"
#include "Triangle.h"
#include "Circle.h"

using namespace std;

double sumArea(Rectangle Rec[2], Square Squ[2] , Triangle Tri[2], Circle Cir[2]){
    double sum = 0;
    for(int i = 0 ; i < 2 ; i++){
        sum += Rec[i].calcArea() + Squ[i].getArea() + Tri[i].calcArea() + Cir[i].calcArea();
    }
    return sum;
}

int main() {
    Rectangle R(10, 20), R2(5, 10);
    cout << endl;
    cout << "Rectangle Area One = " << R.calcArea() << " ||" <<" Rectangle Area Two = " << R2.calcArea() <<endl;
    cout << endl;
    Square S(5), S2(10);
    cout << "Square Area One = " << S.getArea() << " ||" <<" Square Area Two = " << S2.getArea() <<endl;
    cout << endl;
    Triangle T(4, 8), T2(2, 4);
    cout << "Triangle Area = " << T.calcArea() << " ||" <<" Triangle Area Two = " << T2.calcArea() <<endl;
    cout << endl;
    Circle C(4), C2(8);
    cout << "Circle Area One = " << C.calcArea() << " ||" <<" Circle Area Two = " << C2.calcArea() <<endl;
    cout << endl;


    Rectangle arrReq[] = {R, R2};
    Square arrSq[] = {S, S2};
    Triangle arrTr[] = {T, T2};
    Circle arrCr[] = {C, C2};
    cout << "Sum of shapes area = " << sumArea(arrReq,arrSq,arrTr,arrCr) << endl;

    return 0;
}
