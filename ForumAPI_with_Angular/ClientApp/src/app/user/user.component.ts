import { Component, OnInit } from '@angular/core';
import { User } from '../shared/user.model';
import { UserService } from '../shared/user.service';


@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styles: [
  ]
})


export class UserComponent implements OnInit {

  constructor(public service: UserService) { }


  ngOnInit(): void {
    this.service.refreshList();
  }


  populateForm(selectedRecord: User) {
    this.service.formData = Object.assign({}, selectedRecord);
  }


  onDelete(email: string) {
    this.service.deleteUser(email).subscribe(
        res => {
          this.service.refreshList();
        },
        err => { console.log(err) }
      )
  }


}
