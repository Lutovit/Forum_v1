import { Injectable } from '@angular/core';
import { User } from './user.model';
import { UserRegister } from './user-register.model';


import { HttpClient } from "@angular/common/http";


@Injectable({
  providedIn: 'root'
})



export class UserService {

  constructor(private http: HttpClient) {
  }

  readonly _baseUrl = "https://localhost:44335/api/users";

  formData: User = new User();

  newUser: UserRegister = new UserRegister();

  list: User[] = [];

  createUser() {
    return this.http.post(this._baseUrl, this.newUser);
  }


  updateUser() {
    return this.http.put('${ this._baseUrl } / ${ this.formData.id }', this.formData);
  }


  deleteUser(email: string) {
    return this.http.delete(this._baseUrl +'/'+ email);
  }


  refreshList() {
    this.http.get(this._baseUrl).toPromise().then(res => this.list = res as User[]);
    
  }

}
