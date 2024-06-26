import { Component, OnInit, inject } from '@angular/core';
import { MembersService } from '../../_services/members.service';
import { Member } from '../../_models/member';
import { MemberCardComponent } from "../member-card/member-card.component";

@Component({
    selector: 'app-member-list',
    standalone: true,
    templateUrl: './member-list.component.html',
    styleUrl: './member-list.component.css',
    imports: [MemberCardComponent]
})
export class MemberListComponent implements OnInit{
  membersService = inject(MembersService)

  ngOnInit(): void {
    if (this.membersService.members().length === 0) this.loadMembers();
  }

  loadMembers(){
    this.membersService.getMembers();
  }
}
