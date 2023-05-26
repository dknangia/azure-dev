import { DOCUMENT } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { Inject, Injectable } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit{

  public currentDate = new Date();

  /**
   *
   */
  constructor(@Inject(DOCUMENT) private document: Document) {
    
    
  }

  ngOnInit(): void {
    console.log(this.document.location.href);
  }


}
