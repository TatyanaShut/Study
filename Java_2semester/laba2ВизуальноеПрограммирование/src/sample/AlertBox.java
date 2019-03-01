package sample;


import javafx.geometry.Insets;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.scene.layout.GridPane;
import javafx.scene.paint.Color;
import javafx.stage.Modality;
import javafx.stage.Stage;




public class AlertBox {

    public static void display(String title, String message){

    Stage window = new Stage();

    window.initModality(Modality.APPLICATION_MODAL);
    window.setTitle(title);
    window.setMinWidth(250);

    GridPane grid = new GridPane();
    grid.setPadding(new Insets(10,10,10,10));
    grid.setVgap(8);
    grid.setHgap(10);


    Label labelRes = new Label();
    GridPane.setConstraints(labelRes,0,3);


    Label nameLabel = new Label("User name:");
    GridPane.setConstraints(nameLabel, 0, 0);

    TextField nameInput = new TextField("Katerina");
    GridPane.setConstraints(nameInput,1,0);

    Label passLabel = new Label("Password:");
    GridPane.setConstraints(passLabel,0,1);

    PasswordField passInput = new PasswordField();
    passInput.setPromptText("Enter your password");
    GridPane.setConstraints(passInput,1,1);

    Button loginButton = new Button("Log in");
    GridPane.setConstraints(loginButton,1,2);



        loginButton.setOnAction(event -> {

        if (!passInput.getText().equals("1234512345")) {
            labelRes.setText("Your password is incorrect");
            labelRes.setTextFill(Color.RED);
            System.out.println("Your password is incorrect");
        } else{
            labelRes.setText("Your password is correct");
            labelRes.setTextFill(Color.GREEN);
            System.out.println("Your password is correct");
        }
    });


    grid.getChildren().addAll(nameLabel, nameInput, passLabel, passInput,loginButton, labelRes );

    Scene scene = new Scene(grid, 300, 200);
    window.setScene(scene);
    window.showAndWait();
}


}
