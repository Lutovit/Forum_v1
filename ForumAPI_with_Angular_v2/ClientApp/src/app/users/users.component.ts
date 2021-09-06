import { Component, Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html'
})

export class UsersComponent {

  public users: User[];

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    http.get<User[]>(baseUrl + 'api/users').subscribe(result => {this.users = result;}, error => console.error(error));
  }

}


interface User {

  id: string,

  clientName: string,

  companyName: string,

  email: string,

  dateOfRegistration: string,

  isBanned: boolean,

  isDelited: boolean

}
