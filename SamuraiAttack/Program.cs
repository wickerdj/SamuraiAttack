using System;
using Ninject;
using Ninject.Modules;

namespace SamuraiAttack
{




	public interface IWeapon {
		void Hit (string target);
	}

	public class Sword : IWeapon {
		public void Hit(String target) {
			Console.WriteLine ("Chopped {0} clean in half.", target);
		}
	}

	public class Shuriken : IWeapon{
		public void Hit(string target) {
			Console.WriteLine ("Pierces the {0}'s armor.", target);
		}
	}


	public interface IWarrior{
		void Attack (string target);
	}

	public class Samurai: IWarrior {
		private readonly IWeapon _weapon;

		public Samurai(IWeapon weapon) {
			_weapon = weapon;
		}

		public void Attack(string target) {
			_weapon.Hit (target);
		}
	}

	public class WarriorModule:NinjectModule {
		public override void Load() {
			Bind<IWarrior> ().To<Samurai> ();
			Bind<IWeapon> ().To<Sword> ();
		}
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			IKernel kernel = new StandardKernel (new WarriorModule());

			IWarrior samurai = kernel.Get<IWarrior>();

			samurai.Attack ("bad programmers");
			Console.ReadLine ();
		}
	}
}
