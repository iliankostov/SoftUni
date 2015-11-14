#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int inside_board(double, double);
int inside_head(double, double);
int inside_arm(double, double, double, double, double, double);

int main(int argc, char** argv) {

    double boardX, boardY, boardRadius;
    scanf("%lf %lf %lf\n", &boardX, &boardY, &boardRadius);
    double headX, headY, headRadius;
    scanf("%lf %lf %lf\n", &headX, &headY, &headRadius);
    double topLeftX, topLeftY, bottomRightX, bottomRightY;
    scanf("%lf %lf %lf %lf\n", &topLeftX, &topLeftY, &bottomRightX, &bottomRightY);
    int numberOfShots;
    scanf("%d\n", &numberOfShots);

    double points = 0;
    double health = 100;
    int successfulShots = 0;

    double shotX, shotY;
    int i;
    for (i = 0; i < numberOfShots; i++) {

        if (i < numberOfShots - 1) {
            scanf("%lf %lf\n", &shotX, &shotY);
        } else {
            scanf("%lf %lf", &shotX, &shotY);
        }


        double pathToBoardCenter = sqrt(pow(shotX - boardX, 2) + pow(shotY - boardY, 2));
        double pathToHeadCenter = sqrt(pow(shotX - headX, 2) + pow(shotY - headY, 2));

        int hitBoard = inside_board(pathToBoardCenter, boardRadius);
        int hitHead = inside_head(pathToHeadCenter, headRadius);
        int hitArm = inside_arm(shotX, shotY, topLeftX, bottomRightX, topLeftY, bottomRightY);

        if (hitBoard && !hitHead && !hitArm) {
            points += 50;
            successfulShots++;
        }

        if (hitBoard && (hitHead || hitArm)) {
            points += 25;
            health -= 25;
            successfulShots++;

            if (health <= 0) {
                numberOfShots = i + 1;
                health = 0;
                break;
            }
        }

        if (!hitBoard && (hitHead || hitArm)) {
            health -= 30;

            if (health <= 0) {
                numberOfShots = i + 1;
                health = 0;
                break;
            }
        }
    }

    double hitRatio = (successfulShots * 1.0 / numberOfShots) * 100;
    
    printf("Points: %.0f\n", points);
    printf("Hit ratio: %.0f%%\n", hitRatio);
    printf("Bay Mile: %0.f\n", health);

    return (EXIT_SUCCESS);
}

int inside_board(double pathToBoardCenter, double boardRadius) {
    if (pathToBoardCenter <= boardRadius) {
        return 1;
    }

    return 0;
}

int inside_head(double pathToHeadCenter, double headRadius) {
    if (pathToHeadCenter <= headRadius) {
        return 1;
    }

    return 0;
}

int inside_arm(double shotX, double shotY,
        double topLeftX, double bottomRightX,
        double topLeftY, double bottomRightY) {

    if (shotX >= topLeftX && shotX <= bottomRightX && shotY >= bottomRightY && shotY <= topLeftY) {
        return 1;
    }

    return 0;
}