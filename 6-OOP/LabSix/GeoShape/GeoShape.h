//
// Created by Mohamed on 11/30/2023.
//

#ifndef GEOSHAPE_GEOSHAPE_H
#define GEOSHAPE_GEOSHAPE_H


class GeoShape {
      int dim1;
      int dim2;
public:
    GeoShape(int d1 = 0, int d2 = 0){
        dim1 = d1;
        dim2 = d2;
    }
    int &getDim1(){
        return dim1;
    }
    int &getDim2(){
        return dim2;
    }
    void setDim1(int d1){
        dim1 = d1;
    }
    void setDim2(int d2){
        dim2 = d2;
    }
};


#endif //GEOSHAPE_GEOSHAPE_H
