import { Injectable } from "@angular/core";
import { UserService } from "./user.service";
import { LanguageService } from "./language.service";
import { SettingService } from "./settings.service";

@Injectable({
  providedIn: "root"
})
export class InitService {
  private functions = [];
  private loaded = false;

  constructor(private userService: UserService,
    private settingService: SettingService) {
    this.Load();
  }

  public Load() {
    return this.userService.Load().then(() => {
      let inits = [
        this.settingService.Load()
      ];

      return Promise.all(inits).then(() => {
        this.loaded = true;
        for (let i = 0; i < this.functions.length; i++) {
          this.functions[i]();
        }
      });
    });
  }

  public Register(func: Function) {
    if (this.loaded) {
      func();
    } else {
      this.functions.push(func);
    }
  }
}