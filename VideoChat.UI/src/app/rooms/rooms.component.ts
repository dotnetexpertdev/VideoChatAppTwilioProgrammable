import { Component, OnInit, OnDestroy, EventEmitter, Output, Input } from '@angular/core';
import { Subscription } from 'rxjs';
import { tap } from 'rxjs/operators';
import { NamedRoom, VideochatService } from '../services/videochat.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-rooms',
  styleUrls: ['./rooms.component.css'],
  imports: [CommonModule, FormsModule],
  standalone: true,
  templateUrl: './rooms.component.html',
})
export class RoomsComponent {
  @Output() roomChanged = new EventEmitter<string>();
  @Input()
  activeRoomName!: any;

  roomName!: any;
  rooms!: NamedRoom[];

  private subscription: Subscription | undefined;

  constructor(
    private readonly videochatService: VideochatService) { }

  async ngOnInit() {
    await this.updateRooms();
    this.subscription =
      this.videochatService
        .$roomsUpdated
        .pipe(tap(_ => this.updateRooms()))
        .subscribe();
  }

  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  onTryAddRoom() {
    if (this.roomName) {
      this.onAddRoom(this.roomName);
    }
  }

  onAddRoom(roomName: string) {
    this.roomName = null;
    this.roomChanged.emit(roomName);
  }

  onJoinRoom(roomName: string) {
    this.roomChanged.emit(roomName);
  }

  async updateRooms() {
    this.rooms = (await this.videochatService.getAllRooms()) as NamedRoom[];
  }
}
