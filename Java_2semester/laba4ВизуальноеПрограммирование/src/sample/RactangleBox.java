package sample;

import javafx.scene.Scene;
import javafx.scene.layout.VBox;
import javafx.stage.Modality;
import javafx.stage.Stage;
import javafx.scene.shape.Rectangle;

public class RactangleBox {

    public static void display(){


        Stage window  = new Stage();
        window.initModality(Modality.APPLICATION_MODAL);
        window.setTitle("Рисуем прямоугольник");


        VBox layout = new VBox();
        layout.setMaxWidth(300);
        Scene scene = new Scene(layout);

        Rectangle roundRect = new Rectangle();
        roundRect.setX(50);
        roundRect.setY(50);
        roundRect.setWidth(100);
        roundRect.setHeight(130);

        roundRect.setArcWidth(20);
        roundRect.setArcHeight(50);

        layout.getChildren().add(roundRect);

        window.setScene(scene);
        window.showAndWait();


    }
}
