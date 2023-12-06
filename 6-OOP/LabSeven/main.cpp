#include <iostream>
#include "C:\Program Files\CodeBlocks\MinGW\include\graphics.h"

using namespace std;

class shape{
  int color;
  public:
      shape(int _color){
          color = _color;
      }
      int &getColor(){
         return color;
      }
      virtual void draw() = 0;
};

class Point {
private:
    int x;
    int y;

public:
    Point(int x, int y) {
        this->x = x;
        this->y = y;
    }

    Point(int cor) : Point(cor, cor) {
    }

    Point() : Point(0, 0) {
    }

    ~Point() = default;

    void setX(int cor) {
        x = cor;
    }

    void setY(int cor) {
        y = cor;
    }

    int getX() const {
        return x;
    }

    int getY() const {
        return y;
    }

    void print() const {
        cout << "X-COR: " << x << " || Y-COR: " << y << endl;
    }
};


class MyLine : public shape{
private:
    Point start;
    Point end;
public:
    MyLine(int x1, int y1, int x2, int y2, int c) : start(x1, y1), end(x2, y2), shape(c) {

    }

    MyLine() : MyLine(0, 0, 0, 0, 0) {
    }

    ~MyLine() = default;

    void print() const {
        cout << "The Line Details:" << endl;
        cout << "=================" << endl;
        cout << "\tStart Point ->  ";
        start.print();

        cout << "\tEnd Point   ->  ";
        end.print();
    }

    void draw()  {
        setcolor(getColor());
        line(start.getX(), start.getY(), end.getX(), end.getY());
    }
};

class MyRectangle : public shape{
private:
    Point upperL;
    Point lowerR;
public:
    MyRectangle(int x1, int y1, int x2, int y2, int c) : upperL(x1, y1), lowerR(x2, y2), shape(c) {

    }

    MyRectangle() : MyRectangle(0, 0, 0, 0, 0) {
    }

    ~MyRectangle() = default;

    void setUpperL(int x, int y) {
        upperL.setX(x);
        upperL.setY(y);
    }

    void setLowerR(int x, int y) {
        lowerR.setX(x);
        lowerR.setY(y);
    }

    void setColor(int c) {
        getColor() = c;
    }

    Point getUpperL() const {
        return upperL;
    }

    Point getLowerR() const {
        return lowerR;
    }

    void print() const {
        cout << "The Rectangle Details:" << endl;
        cout << "======================" << endl;
        cout << "\tUpper Left Point  ->  ";
        upperL.print();
        cout << "\tLower Right Point ->  ";
        lowerR.print();
    }

    void draw()  {
        setcolor(getColor());
        rectangle(upperL.getX(), upperL.getY(), lowerR.getX(), lowerR.getY());
    }
};


class MyCircle : public shape{
private:
    Point center;
    int radius;

public:
    MyCircle(int x, int y, int r, int c) : center(x, y), radius(r), shape(c) {

    }

    MyCircle() : MyCircle(0, 0, 0, 0) {
    }

    ~MyCircle() = default;

    void setRadius(int r) {
        radius = (r >= 0) ? r : 0;
    }

    int getRadius() const {
        return radius;
    }

    void print() const {
        cout << "The Circle Details:" << endl;
        cout << "===================" << endl;
        cout << "\tCenter Point ->  ";
        center.print();
        cout << "\tRadius       ->  " << getRadius() << endl;
    }

    void draw()  {
        setcolor(getColor());
        circle(center.getX(), center.getY(), radius);
    }
};


class MyTriangle : public shape{
private:
    Point first;
    Point second;
    Point third;

public:
    MyTriangle(int x1, int y1, int x2, int y2, int x3, int y3, int c) : first(x1, y1), second(x2, y2), third(x3, y3), shape(c) {

    }

    MyTriangle() : MyTriangle(0, 0, 0, 0, 0, 0, 0) {
    }

    ~MyTriangle() = default;

    void print() const {
        cout << "The Triangle Details:" << endl;
        cout << "=====================" << endl;
        cout << "\tFirst Point  ->  ";
        first.print();
        cout << "\tSecond Point ->  ";
        second.print();
        cout << "\tThird Point  ->  ";
        third.print();
    }

    void draw()  {
        setcolor(getColor());
        line(first.getX(), first.getY(), second.getX(), second.getY());
        line(second.getX(), second.getY(), third.getX(), third.getY());
        line(third.getX(), third.getY(), first.getX(), first.getY());
    }

};

class Pic
{
    MyRectangle *pRec;
    MyCircle *pCir;
    MyTriangle *pTri;
    MyLine *pLin;
    int rNum, cNum, tNum, lNum;
public:
    Pic(MyRectangle *_pRec, MyCircle *_pCir, MyTriangle *_pTri, MyLine *_pLin,
        int _rNum, int _cNum, int _tNum, int _lNum)
    {
        pRec = _pRec;
        pCir = _pCir;
        pTri = _pTri;
        pLin = _pLin;
        rNum = _rNum;
        cNum = _cNum;
        tNum = _tNum;
        lNum = _lNum;
    }
    ~Pic(){
       cout << "BYE!" << endl;
    }
    void setRec(MyRectangle *_pRec){
         pRec = _pRec;
    }
     void setCir(MyCircle *_pCir){
         pCir = _pCir;
    }
     void setTri(MyTriangle *_pTri){
         pTri = _pTri;
    }
     void setLin(MyLine *_pLin){
         pLin = _pLin;
    }
    MyRectangle getRec(){
        return *pRec;
    }
    MyCircle getCir(){
        return *pCir;
    }
    MyTriangle getTri(){
        return *pTri;
    }
    MyLine getLine(){
        return *pLin;
    }
    void paintRec(){
       for(int i = 0 ; i < rNum ; i++){
           pRec[i].draw();
       }
    }
    void paintCir(){
       for(int i = 0 ; i < cNum ; i++){
           pCir[i].draw();
       }
    }
    void paintTri(){
       for(int i = 0 ; i < tNum ; i++){
           pTri[i].draw();
       }
    }
    void paintLine(){
       for(int i = 0 ; i < rNum ; i++){
           pLin[i].draw();
       }
    }

};

class PicTwo
{
    shape **pShape;
    int size;
public:
    PicTwo(shape **_pShape, int _size){
        pShape = _pShape;
        size = _size;
    }
    void setShape(shape **_pShape){
         pShape = _pShape;
    }
    shape** getShape(){
        return pShape;
    }
    void printShape(){
      for(int i = 0 ; i < size ; i++){
          pShape[i]->draw();
       }
    }
};
int main()
{
    initgraph();
   /*MyRectangle *Rec = new MyRectangle[1];
    Rec[0] = MyRectangle(354, 296, 677, 442, 4);
    MyCircle *Cir = new MyCircle[2];
    Cir[0] = MyCircle(512, 199, 130, 4);
    Cir[1] = MyCircle(512, 86, 78, 4);
    MyTriangle *Tri = new MyTriangle[1];
    Tri[0] = MyTriangle (635, 346, 608, 381, 660, 380, 4);
    MyLine *Line = new MyLine[4];
    Line[0] =  MyLine(490, 296, 490, 240, 4);
    Line[1] =  MyLine(540, 296, 540, 240, 4);
    Line[2] =  MyLine(474, 84, 449, 196, 4);
    Line[3] =  MyLine(550, 82, 571, 194, 4);

    shape *arr[8] = {Rec, Cir, &Cir[1], Tri, Line, &Line[1], &Line[2], &Line[3]};
    PicTwo p(arr, 8);
    p.printShape();*/

    MyRectangle *Rec = new MyRectangle[1];
    Rec[0] = MyRectangle(354, 296, 677, 442, 4);
    MyCircle *Cir = new MyCircle[2];
    Cir[0] = MyCircle(512, 199, 130, 4);
    Cir[1] = MyCircle(512, 86, 78, 4);
    MyTriangle *Tri = new MyTriangle[1];
    Tri[0] = MyTriangle (635, 346, 608, 381, 660, 380, 4);
    MyLine *Line = new MyLine[4];
    Line[0] =  MyLine(490, 296, 490, 240, 4);
    Line[1] =  MyLine(540, 296, 540, 240, 4);
    Line[2] =  MyLine(474, 84, 449, 196, 4);
    Line[3] =  MyLine(550, 82, 571, 194, 4);



    Pic P(Rec, Cir, Tri, Line, 1, 2, 1, 4);
    P.paintRec();
    P.paintCir();
    P.getTri();
    P.paintLine();

    /*MyLine l1(490, 296, 490, 240, 4), l2(540, 296, 540, 240, 4), l3(474, 84, 449, 196, 4), l4(550, 82, 571, 194, 4);
    MyRectangle r(354, 296, 677, 442, 4);
    MyCircle c1(512, 199, 130, 4), c2(512, 86, 78, 4);
    MyTriangle t(635, 346, 608, 381, 660, 380, 4);

    l1.draw();
    l2.draw();
    l3.draw();
    l4.draw();
    c1.draw();
    c2.draw();
    r.draw();
    t.draw();*/
    return 0;
}
