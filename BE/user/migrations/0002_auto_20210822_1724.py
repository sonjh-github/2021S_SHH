# Generated by Django 3.2.5 on 2021-08-22 08:24

from django.db import migrations


class Migration(migrations.Migration):

    dependencies = [
        ('user', '0001_initial'),
    ]

    operations = [
        migrations.RenameField(
            model_name='user',
            old_name='userId',
            new_name='password',
        ),
        migrations.RenameField(
            model_name='user',
            old_name='userPw',
            new_name='phoneNumber',
        ),
    ]
