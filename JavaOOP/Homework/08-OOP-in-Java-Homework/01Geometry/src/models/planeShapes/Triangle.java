package models.planeShapes;

import models.PlaneShape;
import models.Vertex2D;

public class Triangle extends PlaneShape {
    public Triangle(Vertex2D a, Vertex2D b, Vertex2D c) {
        super(new Vertex2D[]{a, b, c});
    }

    @Override
    public double getPerimeter() {
        double perimeter = this.getSides()[0] + this.getSides()[1] + this.getSides()[2];

        return perimeter;
    }

    @Override
    public String getShapeName() {
        return "Triangle";
    }

    // Heron's Formula
    @Override
    public double getArea() {
        double area = Math.sqrt(
                (this.getPerimeter() / 2) *
                ((this.getPerimeter() / 2 - this.getSides()[0]) *
                (this.getPerimeter() / 2 - this.getSides()[1]) *
                (this.getPerimeter() / 2 - this.getSides()[2])));

        return area;
    }

    @Override
    public String toString() {
        StringBuilder triangleInfo = new StringBuilder();
        triangleInfo.append(String.format("%s\r\n", this.getShapeName()));
        triangleInfo.append(String.format(
        "point coordinates: a %s, b %s, c %s\r\n",
        getVertices2D()[0],
        getVertices2D()[1],
        getVertices2D()[2]));
        triangleInfo.append(String.format("area = %.2f\r\n", this.getArea()));
        triangleInfo.append(String.format("perimeter = %.2f", this.getPerimeter()));

        return triangleInfo.toString();
    }

    private double[] getSides() {
        double firstSide = getDistanceBetweenTwoPoints(getVertices2D()[1], getVertices2D()[2]);
        double secondSide = getDistanceBetweenTwoPoints(getVertices2D()[2], getVertices2D()[0]);
        double thirdSide = getDistanceBetweenTwoPoints(getVertices2D()[0], getVertices2D()[1]);
        double[] sides = {firstSide, secondSide, thirdSide};

        return sides;
    }

    private double getDistanceBetweenTwoPoints(Vertex2D firstPoint, Vertex2D secondPoint) {
        double deltaX = firstPoint.getX() - secondPoint.getX();
        double deltaY = firstPoint.getY() - secondPoint.getY();

        double distance = Math.sqrt(
                Math.pow(deltaX, 2) +
                Math.pow(deltaY, 2));

        return distance;
    }
}