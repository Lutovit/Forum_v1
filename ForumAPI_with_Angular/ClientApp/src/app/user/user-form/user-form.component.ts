import { Component, OnInit } from '@angular/core';
import { UserService } from '../../shared/user.service';
import { NgForm } from '@angular/forms';
import { User } from '../../shared/user.model';




@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styles: [
  ]
})



export class UserFormComponent implements OnInit {

  constructor(public service: UserService) {
  }


  ngOnInit(): void {
  }


  onSubmit(form: NgForm) {
      this.insertRecord(form);
  }


  insertRecord(form: NgForm) {

    this.service.createUser().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
      },
      err => {
        console.log(err);
      }
    );

  }


  updateRecord(form: NgForm) {
    this.service.updateUser().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshList();
      },
      err => {
        console.log(err);
      }
    );
  }


  resetForm(form: NgForm) {
    form.form.reset();
    this.service.formData = new User();
  }



}
