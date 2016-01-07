﻿using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TDSServer.GroundTask;

namespace TDSServer
{
    public class GameObject
    {
        internal GameManager m_GameManager;
        private double LastExClockTick = 0;
        private int ExClockResolution = 200;  //200 milisec  5 times per second

        public DateTime Ex_clockDate;
        public DateTime Ex_clockGroundExecute = DateTime.MinValue;
        public Task GroundExecuteStateTask = null;


        internal ConcurrentDictionary<string, AtomBase> GroundAtomObjectCollection = new ConcurrentDictionary<string, AtomBase>();
        public Dictionary<string, List<clsActivityBase>> m_GroundActivities = new Dictionary<string, List<clsActivityBase>>();


        internal GameObject(GameManager refGameManager)
        {
            m_GameManager =refGameManager;
        }
        internal void InitObjects()
        {
            Ex_clockDate = DateTime.Now;
            GroundAtomsInit();

            GroundMissionActivitiesInit();

        }
        private void GroundMissionActivitiesInit()
        {
              m_GroundActivities = new Dictionary<string, List<clsActivityBase>>();
              foreach (KeyValuePair<string, AtomBase> keyVal in GroundAtomObjectCollection)
              {
                  clsGroundAtom refGroundAtom = keyVal.Value as clsGroundAtom;

                  IEnumerable<GeneralActivityDTO> ActivitesDTO = TDS.DAL.ActivityDB.GetMovementActivitesByAtom(refGroundAtom.GUID);
                  List<clsActivityBase> Activites=new List<clsActivityBase>();
                  foreach(GeneralActivityDTO dto in ActivitesDTO )
                  {
                      clsActivityMovement MovementAct = new clsActivityMovement();
                      MovementAct.ActivityType = enumActivity.MovementActivity;   
                      MovementAct.ActivityId = dto.ActivityId;
                      MovementAct.AtomGuid=refGroundAtom.GUID;
                      MovementAct.AtomName = refGroundAtom.MyName;
                      MovementAct.DurationActivity = dto.DurationActivity;
                      MovementAct.RouteActivity = dto.RouteActivity;
                      MovementAct.Speed = dto.Speed;
                      MovementAct.StartActivityOffset = dto.StartActivityOffset;
                      MovementAct.TimeFrom = Ex_clockDate.Add(MovementAct.StartActivityOffset);
                      MovementAct.TimeTo = MovementAct.TimeFrom.Add(MovementAct.DurationActivity);
                      Activites.Add(MovementAct);
                  }
                  m_GroundActivities.Add(refGroundAtom.GUID, Activites);
              }
        }
        private void GroundAtomsInit()
        {
            GroundAtomObjectCollection = new ConcurrentDictionary<string, AtomBase>();
            IEnumerable<AtomData> atoms = TDS.DAL.AtomsDB.GetAllAtoms();
            if (atoms != null)
            {
                foreach(AtomData atom in atoms)
                {
                    clsGroundAtom GroundAtom = new clsGroundAtom(this);
                    GroundAtom.MyName = atom.UnitName;
                    GroundAtom.GUID = atom.UnitGuid;
                    GroundAtom.curr_X = atom.Location.x;
                    GroundAtom.curr_Y = atom.Location.y;
                    GroundAtomObjectCollection.TryAdd(GroundAtom.GUID, GroundAtom);
                }
            }
        }

        public bool isAtomNameExist(string AtomName)
        {
            AtomData atom = TDS.DAL.AtomsDB.GetAtomByName(AtomName);
            if (atom != null) return true;
            else  return false;
        }
        public bool isRouteNameExist(string RouteName)
        {
            Route route = TDS.DAL.RoutesDB.GetRouteByName(RouteName);
            if (route != null) return true;
            else return false;
        }

        public void DeleteAtomByAtomName(string AtomName)
        {
            AtomData atom = TDS.DAL.AtomsDB.GetAtomByName(AtomName);
            if (atom == null) return;

            AtomBase GroundAtombase = null;
            GroundAtomObjectCollection.TryGetValue(atom.UnitGuid, out GroundAtombase);
            if (GroundAtombase == null) return;
            clsGroundAtom GroundAtom = GroundAtombase as clsGroundAtom;

            TDS.DAL.ActivityDB.DeleteActivitesByAtomGuid(GroundAtom.GUID);


            List<clsActivityBase> Activites = null;
            m_GroundActivities.TryGetValue(GroundAtom.GUID, out Activites);
            if(Activites!=null)
            {
                foreach (clsActivityBase Activity in Activites)
                {
                    TDS.DAL.RoutesDB.DeleteRouteByGuid(Activity.RouteActivity.RouteGuid);
                }
            }

            m_GroundActivities.Remove(GroundAtom.GUID);
            TDS.DAL.AtomsDB.DeleteAtomByGuid(GroundAtom.GUID);
            GroundAtomObjectCollection.TryRemove(GroundAtom.GUID, out GroundAtombase);

            NotifyClientsEndCycleArgs args = new NotifyClientsEndCycleArgs();
            args = new NotifyClientsEndCycleArgs();
            args.Transport2Client.Ex_clockDate = Ex_clockDate;
            // args.Transport2Client.ExClockRatioSpeed = m_GameManager.ExClockRatioSpeed;
            args.Transport2Client.AtomObjectType = 2;
            args.Transport2Client.AtomObjectCollection = PrepareGroundCommonProperty();
            args.Transport2Client.ManagerStatus = m_GameManager.ManagerStatus;
            m_GameManager.NotifyClientsEndCycle(args);

        }
        public void   RefreshActivity(GeneralActivityDTO ActivityDTO)
        {
            AtomBase GroundAtombase = null;
            GroundAtomObjectCollection.TryGetValue(ActivityDTO.Atom.UnitGuid, out GroundAtombase);
            if (GroundAtombase == null)
            {
                clsGroundAtom GroundAtom = new clsGroundAtom(this);
                GroundAtom.MyName = ActivityDTO.Atom.UnitName;
                GroundAtom.GUID = ActivityDTO.Atom.UnitGuid;
                GroundAtom.curr_X = ActivityDTO.Atom.Location.x;
                GroundAtom.curr_Y = ActivityDTO.Atom.Location.y;
                GroundAtomObjectCollection.TryAdd(GroundAtom.GUID, GroundAtom);

                NotifyClientsEndCycleArgs args = new NotifyClientsEndCycleArgs();
                args = new NotifyClientsEndCycleArgs();
                args.Transport2Client.Ex_clockDate = Ex_clockDate;
                // args.Transport2Client.ExClockRatioSpeed = m_GameManager.ExClockRatioSpeed;
                args.Transport2Client.AtomObjectType = 2;
                args.Transport2Client.AtomObjectCollection = PrepareGroundCommonProperty();
                args.Transport2Client.ManagerStatus =   m_GameManager.ManagerStatus;
                m_GameManager.NotifyClientsEndCycle(args);
            }
        }

        internal void Ex_Manager()
        {
             LastExClockTick = Environment.TickCount;
             while(m_GameManager.Ex_ManagerThreadShouldStop==false)
             {
                  if (m_GameManager.ManagerStatus == typGamestatus.PAUSE_STATUS)
                  {
                      if (GroundExecuteStateTask != null && GroundExecuteStateTask.IsCompleted == false)
                      {
                          
                          try
                          {
                              GroundExecuteStateTask.Wait();
                              GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);

                          }
                          catch (AggregateException exx)
                          {
                             // Log.WriteErrorToLog(exx, m_GameManager.curScenario.DbName);
                          }
                      }


                      Thread.Sleep(1000);
                      continue;
                  }
                  else if ((m_GameManager.ManagerStatus == typGamestatus.EDIT_STATUS) || (m_GameManager.ManagerStatus == typGamestatus.PROCESS_RUN2EDIT))
                  {
                      // Thread.CurrentThread.Abort();
                      break;
                  }
              //    m_GameManager.ExClockRatioSpeed = 6;
                  if (m_GameManager.ExClockRatioSpeed != 0)
                  {
                      double currExClockTick = Environment.TickCount;
                      double TickCount = currExClockTick - LastExClockTick;
                    //  int sleepTime = 1000 / m_GameManager.ExClockRatioSpeed - (int)TickCount;
                      int sleepTime = ExClockResolution / m_GameManager.ExClockRatioSpeed - (int)TickCount;
                      if (sleepTime > 0 && sleepTime < Int32.MaxValue)
                      {
                          Thread.Sleep(sleepTime);
                      }
                  }

                


                  

                  //int sleepTime = 1000 / m_GameManager.ExClockRatioSpeed - (int)TickCount;
                  //if (sleepTime > 0 && sleepTime < Int32.MaxValue)
                  //{
                  //    Thread.Sleep(sleepTime);
                  //}
                //  ExClockResolution = 1000;
                  Ex_clockDate = Ex_clockDate.AddMilliseconds(ExClockResolution);



                  LastExClockTick = Environment.TickCount;

                  TimeSpan TSGroundExecute = Ex_clockDate.Subtract(Ex_clockGroundExecute);
                  if (TSGroundExecute.TotalMilliseconds >= m_GameManager.GroundCycleResolution)
                  {
                      Ex_clockGroundExecute = Ex_clockDate;

                      if (GroundExecuteStateTask != null)
                      {
                          try
                          {
                              GroundExecuteStateTask.Wait();
                              GroundExecuteStateTask.Dispose();
                              GroundExecuteStateTask = null;
                          }
                          catch (AggregateException Exx)
                          {
                              GroundExecuteStateTask.Dispose();
                              GroundExecuteStateTask = null;
                             // GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                             // Log.WriteErrorToLog(Exx, m_GameManager.curScenario.DbName);
                          }
                      }


                      GroundExecuteStateTask = new Task(() =>
                      {
                          foreach (KeyValuePair<string, AtomBase> keyVal in GroundAtomObjectCollection)
                          {
                              clsGroundAtom refGroundAtom = keyVal.Value as clsGroundAtom;
                              refGroundAtom.ExecuteState();
                              refGroundAtom.CheckCondition();
                          }

                          NotifyClientsEndCycleArgs args = new NotifyClientsEndCycleArgs();
                          args = new NotifyClientsEndCycleArgs();
                          args.Transport2Client.Ex_clockDate = Ex_clockDate;
                          // args.Transport2Client.ExClockRatioSpeed = m_GameManager.ExClockRatioSpeed;
                          args.Transport2Client.AtomObjectType = 2;
                          args.Transport2Client.AtomObjectCollection = PrepareGroundCommonProperty();
                          args.Transport2Client.ManagerStatus = m_GameManager.ManagerStatus;
                          m_GameManager.NotifyClientsEndCycle(args);

                      }
                     );
                      GroundExecuteStateTask.Start();



                  }

                  Thread.Sleep(5);  // (10);   

                 

             }
        }
        internal structTransportCommonProperty[] PrepareGroundCommonProperty()
        {
            List<structTransportCommonProperty> TransportCommonProperty = new List<structTransportCommonProperty>(GroundAtomObjectCollection.Count);
            foreach (KeyValuePair<string, AtomBase> keyVal in GroundAtomObjectCollection)
            {
                clsGroundAtom refGroundAtom = keyVal.Value as clsGroundAtom;

                structTransportCommonProperty CommonPropertyObject = new structTransportCommonProperty();
                CommonPropertyObject.AtomClass = refGroundAtom.GetType().ToString();
                CommonPropertyObject.AtomName = refGroundAtom.MyName;
                CommonPropertyObject.X = refGroundAtom.curr_X;
                CommonPropertyObject.Y = refGroundAtom.curr_Y;

                TransportCommonProperty.Add(CommonPropertyObject);
               
            }
            return TransportCommonProperty.ToArray<structTransportCommonProperty>();
        }
    }
}