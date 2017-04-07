from django.shortcuts import render, redirect
from .models import League, Team, Player

from . import team_maker

def index(request):
	context = {
		"all_leagues": League.objects.all(),
		"baseball_leagues": League.objects.all().filter(sport__contains="baseball"), #1
		"womens_leagues": League.objects.all().filter(name__contains="womens"), #2
		"hockey_leagues": League.objects.all().filter(sport__contains="hockey"), #3
		"notFottball_leagues": League.objects.all().exclude(sport__contains="football"), #4
		"conferences_leagues": League.objects.all().filter(name__contains="conference"), #5
		"atlantic_leagues": League.objects.all().filter(name__contains="atlantic"), #6

		"all_teams": Team.objects.all(),
		"dallas_teams": Team.objects.all().filter(location__contains="dallas"), #7
		"raptors_teams": Team.objects.all().filter(team_name__contains="raptors"), #8
		"city_teams": Team.objects.all().filter(location__contains="city"), #9
		"nameT_teams": Team.objects.all().filter(team_name__startswith="t"), #10
		"alphabetical_teams": Team.objects.all().order_by("location"), #11
		"reAlphabetical_teams": Team.objects.all().order_by("-team_name"), #12

		"all_players": Player.objects.all(),
		"lastCooper_players": Player.objects.all().filter(last_name__contains="cooper"), #13
		"firstJoshua_players": Player.objects.all().filter(first_name__contains="joshua"), #14
		"lastCooperXjashua_players": Player.objects.all().filter(last_name__contains="cooper").exclude(first_name__contains="joshua"), #15
		"firstAlexanderORwyatt_players": Player.objects.all().filter(first_name__contains="alexander")|Player.objects.all().filter(first_name__contains="wyatt"), #16

	}
	return render(request, "leagues/index.html", context)

def make_data(request):
	team_maker.gen_leagues(10)
	team_maker.gen_teams(50)
	team_maker.gen_players(200)

	return redirect("index")
