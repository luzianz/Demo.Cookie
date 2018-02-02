using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Demo.Cookie {

	public class Startup {

		public void Configure(IApplicationBuilder app) {
			app.Run(async(context) => {
				if (context.Request.Cookies.TryGetValue("id", out string id)) {
					await context.Response.WriteAsync($"U got cookie! {id}");
				} else {
					context.Response.Cookies.Append("id", Guid.NewGuid().ToString());
					await context.Response.WriteAsync("Have cookie, then refresh");
				}
			});
		}
	}
}