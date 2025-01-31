import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material';


import { UserService } from '../services/user.service';
import { User } from '../models/user';

@Component({
    templateUrl: 'home.component.html',
    selector: 'home.component.ts',
    styleUrls: ['home.component.scss'],

})

export class HomeComponent implements OnInit {

    constructor(private userService: UserService) { }

    @ViewChild('sidenav', { static: false }) sidenav: MatSidenav;

    reason = '';

    shouldRun = [/(^|\.)plnkr\.co$/, /(^|\.)stackblitz\.io$/].some(h => h.test(window.location.host));

    users: User[] = [];

    close(reason: string) {
        this.reason = reason;
        this.sidenav.close();
    }

    ngOnInit() {
        this.userService.getAll().pipe(first()).subscribe(users => {
            this.users = users;
        });
    }
}


/** @title Sidenav with custom escape and backdrop click behavior */

