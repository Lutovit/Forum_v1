import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { User  } from './user';


@Component({
    templateUrl: './user-list.component.html'
})


export class UserListComponent implements OnInit
{

    users: User[];

    constructor(private dataService: DataService)
    {

    }


    ngOnInit()
    {
        this.load();
    }


    load()
    {
        this.dataService.getUsers().subscribe((data: User[]) => this.users = data);
    }


    delete(id: number)
    {
        this.dataService.deleteUser(id).subscribe(data => this.load());
    }
}