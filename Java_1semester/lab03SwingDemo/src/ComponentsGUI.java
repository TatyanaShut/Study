/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author tatyanashut
 */
import javax.swing.DefaultListModel;



import javax.swing.*;
import java.awt.BorderLayout;
import java.awt.event.*;
import java.io.PrintStream;
import java.io.FileOutputStream;
import java.io.FileNotFoundException;

public class ComponentsGUI extends javax.swing.JFrame {

    private Contact contact;
    private static String name;
    private static String surname;
    private DefaultListModel<String> listModel;
    private Double sum;
    
  
    
    public ComponentsGUI(String firstLine, String secondLine, String adressLine, String managerName, String title) throws FileNotFoundException {
        listModel = new DefaultListModel<>();
        
        String fullManagerName = "Manager: " + managerName;
        
        listModel.addElement(firstLine);
        listModel.addElement(secondLine);
        listModel.addElement(adressLine);
        listModel.addElement(fullManagerName);
        listModel.addElement(title);
        listModel.addElement("----------------");
        sum = 0.0;
        initComponents();
        jList1.setModel(listModel);
        NameText.setText(name);
        PriceText.setText(surname);
        
        String summ =Double.toString(sum);
      String [] data = {firstLine,secondLine,adressLine,managerName,title,name,surname,summ};
      
      JFrame frame = new JFrame();
        frame.add( new JScrollPane( new JList( data )));
      
       final PrintStream out = new PrintStream(new FileOutputStream("datos.txt"));
      frame.add( new JButton("Print"){{
            addActionListener( new ActionListener() {
                public void actionPerformed( ActionEvent e ) {
                    for( Object d : data ) { 
                            out.println( d );
                    }
                }
            });
        }}, BorderLayout.SOUTH);
        frame.pack();
        frame.setVisible( true );
      
      
      
      
      
      
      
      
      
      
      
    }

    
   
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {
        bindingGroup = new org.jdesktop.beansbinding.BindingGroup();

        ContactLabel = new javax.swing.JLabel();
        NameLabel = new javax.swing.JLabel();
        PriceLabel = new javax.swing.JLabel();
        CancelLabel = new javax.swing.JButton();
        SaveLabel = new javax.swing.JButton();
        NameText = new javax.swing.JTextField();
        PriceText = new javax.swing.JTextField();
        jScrollPane2 = new javax.swing.JScrollPane();
        jList1 = new javax.swing.JList<>();
        jButton1 = new javax.swing.JButton();
        SaveChek = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        ContactLabel.setFont(new java.awt.Font("Lucida Grande", 1, 14)); // NOI18N
        ContactLabel.setText("ЧЕК");

        NameLabel.setText("Наименование продукта");

        PriceLabel.setText("Цена");

        CancelLabel.setText("Отменить");
        CancelLabel.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                CancelLabelActionPerformed(evt);
            }
        });

        SaveLabel.setText("Сохранить");
        SaveLabel.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                SaveLabelActionPerformed(evt);
            }
        });

        PriceText.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                PriceTextActionPerformed(evt);
            }
        });

        jList1.setModel(new javax.swing.AbstractListModel<String>() {
            String[] strings = { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" };
            public int getSize() { return strings.length; }
            public String getElementAt(int i) { return strings[i]; }
        });

        org.jdesktop.beansbinding.Binding binding = org.jdesktop.beansbinding.Bindings.createAutoBinding(org.jdesktop.beansbinding.AutoBinding.UpdateStrategy.READ_WRITE, SaveLabel, org.jdesktop.beansbinding.ObjectProperty.create(), jList1, org.jdesktop.beansbinding.BeanProperty.create("elements"));
        bindingGroup.addBinding(binding);

        jScrollPane2.setViewportView(jList1);

        jButton1.setText("Итого");
        jButton1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButton1ActionPerformed(evt);
            }
        });

        SaveChek.setText(" Сохранить чек ");

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addGap(200, 200, 200)
                        .addComponent(ContactLabel))
                    .addGroup(layout.createSequentialGroup()
                        .addGap(53, 53, 53)
                        .addComponent(CancelLabel)
                        .addGap(106, 106, 106)
                        .addComponent(SaveLabel)))
                .addContainerGap(57, Short.MAX_VALUE))
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(layout.createSequentialGroup()
                        .addComponent(jScrollPane2)
                        .addGap(16, 16, 16))
                    .addGroup(layout.createSequentialGroup()
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                            .addComponent(NameLabel)
                            .addComponent(PriceLabel))
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addComponent(NameText, javax.swing.GroupLayout.Alignment.TRAILING)
                            .addComponent(PriceText))
                        .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                            .addGroup(layout.createSequentialGroup()
                                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                                .addComponent(jButton1))
                            .addGroup(layout.createSequentialGroup()
                                .addGap(7, 7, 7)
                                .addComponent(SaveChek)))
                        .addGap(6, 6, 6))))
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addGap(15, 15, 15)
                .addComponent(ContactLabel)
                .addGap(18, 18, 18)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(NameText, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(NameLabel)
                    .addComponent(jButton1))
                .addGap(19, 19, 19)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(PriceLabel)
                    .addComponent(PriceText, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                    .addComponent(SaveChek))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 32, Short.MAX_VALUE)
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE)
                    .addComponent(CancelLabel)
                    .addComponent(SaveLabel))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED)
                .addComponent(jScrollPane2, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(20, 20, 20))
        );

        bindingGroup.bind();

        pack();
    }// </editor-fold>//GEN-END:initComponents

    private void PriceTextActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_PriceTextActionPerformed
       
    }//GEN-LAST:event_PriceTextActionPerformed

    private void CancelLabelActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_CancelLabelActionPerformed
        
DefaultListModel model = (DefaultListModel) jList1.getModel(); 
int selectedIndex = jList1.getSelectedIndex(); 
if (selectedIndex != -1) { 
    //listModel.remove(selectedIndex); 
     model.remove(selectedIndex);
     
   jList1.getModel();
   
     
 
 
} 

    }//GEN-LAST:event_CancelLabelActionPerformed

    private void SaveLabelActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_SaveLabelActionPerformed
        saveContact();
       
        
    }//GEN-LAST:event_SaveLabelActionPerformed

    private void jButton1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButton1ActionPerformed
        String summa = "Итого: " + "$"+ sum;
        listModel.addElement(summa);        
    }//GEN-LAST:event_jButton1ActionPerformed

    private void saveContact(){
        
    String name = NameText.getText();
    String cost = PriceText.getText();
    Contact contact = new Contact(name, cost);
    String fullName = contact.getName() + " " + "$"+contact.getCost();
    listModel.addElement(fullName);
    
    //int price = Integer.parseInt(PriceText.getText());
    Double price = Double.parseDouble(PriceText.getText());
    sum = (double)Math.round((sum + price)* 100d)/ 100d;
   
   
    
    }
    
    
 
    
    
    public static void main(String args[]) {
        /* Set the Nimbus look and feel */
        //<editor-fold defaultstate="collapsed" desc=" Look and feel setting code (optional) ">
        /* If Nimbus (introduced in Java SE 6) is not available, stay with the default look and feel.
         * For details see http://download.oracle.com/javase/tutorial/uiswing/lookandfeel/plaf.html 
         */
        try {
            for (javax.swing.UIManager.LookAndFeelInfo info : javax.swing.UIManager.getInstalledLookAndFeels()) {
                if ("Nimbus".equals(info.getName())) {
                    javax.swing.UIManager.setLookAndFeel(info.getClassName());
                    break;
                }
            }
        } catch (ClassNotFoundException ex) {
            java.util.logging.Logger.getLogger(ComponentsGUI.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (InstantiationException ex) {
            java.util.logging.Logger.getLogger(ComponentsGUI.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (IllegalAccessException ex) {
            java.util.logging.Logger.getLogger(ComponentsGUI.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        } catch (javax.swing.UnsupportedLookAndFeelException ex) {
            java.util.logging.Logger.getLogger(ComponentsGUI.class.getName()).log(java.util.logging.Level.SEVERE, null, ex);
        }
        //</editor-fold>

        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {
            public void run() {
              //  new ComponentsGUI(" ", " "," "," "," ").setVisible(true);
            }
        });
        
     //   final Object [] data = {firstLine,secondLine,adressLine,managerName,title,name,surname,summ};
      
       
        
        
        
        
        
        
        
        
        
        
        
        
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton CancelLabel;
    private javax.swing.JLabel ContactLabel;
    private javax.swing.JLabel NameLabel;
    private javax.swing.JTextField NameText;
    private javax.swing.JLabel PriceLabel;
    private javax.swing.JTextField PriceText;
    private javax.swing.JButton SaveChek;
    private javax.swing.JButton SaveLabel;
    private javax.swing.JButton jButton1;
    private javax.swing.JList<String> jList1;
    private javax.swing.JScrollPane jScrollPane2;
    private org.jdesktop.beansbinding.BindingGroup bindingGroup;
    // End of variables declaration//GEN-END:variables
}
