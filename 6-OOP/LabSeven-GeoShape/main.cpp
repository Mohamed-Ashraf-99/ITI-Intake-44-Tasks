#include <iostream>
#include "GeoShape.h"
#include "Rectangle.h"
#include "Square.h"
#include "Triangle.h"
#include "Circle.h"

using namespace std;

double sumArea(GeoShape **geo, int size){
    double sum = 0;
    for(int i = 0 ; i < size; i++){
        sum += geo[i]->calcArea();
    }
    return sum;
}

int main() {
    Rectangle Rec[2]{{10, 20}, {5, 10}};
    cout << endl;
    cout << "Rectangle Area One = " << Rec[0].calcArea() << " ||" <<" Rectangle Area Two = " << Rec[1].calcArea() <<endl;
    cout << endl;
    Square Sq[2]{{5}, {10} };
    cout << "Square Area One = " << Sq[0].getArea() << " ||" <<" Square Area Two = " << Sq[1].getArea() <<endl;
    cout << endl;
    Triangle T[2]{{4, 8}, {2, 4}};
    cout << "Triangle Area = " << T[0].calcArea() << " ||" <<" Triangle Area Two = " << T[1].calcArea() <<endl;
    cout << endl;
    Circle C[2]{{4}, {8}};
    cout << "Circle Area One = " << C[0].calcArea() << " ||" <<" Circle Area Two = " << C[1].calcArea() <<endl;
    cout << endl;

    GeoShape *arr[8]={Rec, &Rec[1], Sq,&Sq[1], T, &T[1], C, &C[1]};
//    Rectangle arrReq[] = {R, R2};
//    Square arrSq[] = {S, S2};
//    Triangle arrTr[] = {T, T2};
//    Circle arrCr[] = {C, C2};
    cout << "Sum of shapes area = " << sumArea(arr, 8) << endl;

    return 0;
}
