cmake_minimum_required(VERSION 3.26)
project(GeoShape)

set(CMAKE_CXX_STANDARD 17)

add_executable(GeoShape main.cpp
        GeoShape.h
        Rectangle.h
        Square.h
        Triangle.h
        Circle.h)
