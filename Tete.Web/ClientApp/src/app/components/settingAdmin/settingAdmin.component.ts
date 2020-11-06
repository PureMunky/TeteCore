import { Component } from "@angular/core";
import { ApiService } from "../../services/api.service";
import { UserService } from "../../services/user.service";

@Component({
  selector: "setting-admin",
  templateUrl: "./settingAdmin.component.html"
})
export class SettingAdminComponent {
  public settings = [];
  public working = {
    key: '',
    value: '',
    status: ''
  };

  constructor(
    private apiService: ApiService,
    private userService: UserService
  ) {
    this.loadSettings();
  }

  public loadSettings() {
    this.working.status = '';
    return this.apiService.get("V1/Settings/Get")
      .then(data => {
        this.settings = data;
      });
  };

  public save(setting) {
    setting.status = "Saving";
    return this.apiService.post("V1/Settings/Post", setting).then(() => {
      setting.status = "Saved";
    });
  }

  public delete(setting) {
    setting.status = "Deleting";
    return this.apiService.post("V1/Settings/Delete", setting).then(() => {
      setting.status = "Deleted";
    });
  }

  public async create() {
    await this.save(this.working);
    this.settings.push({
      Key: this.working.key.trim(),
      Value: this.working.value,
      status: this.working.status
    });
    this.cancel();
  }

  public cancel() {
    this.working.key = '';
    this.working.value = '';
  }

}
